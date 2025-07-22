import os
from lxml import etree

MODS_FOLDER = r"C:\\Program Files (x86)\\Steam\\steamapps\\workshop\\content\\294100"  # <- Path to mods from workshop
OUTPUT_FILE = os.path.join("Patches", "PropagandaAutoPatches.xml")
sculpture_sizes = ["Small", "Large", "Grand"]


def find_styles_in_mods(mods_folder):
    mods_with_styles = []
    seen_def_names = set()

    for mod_folder in os.listdir(mods_folder):
        mod_path = os.path.join(mods_folder, mod_folder)
        about_path = os.path.join(mod_path, "About", "About.xml")

        if not os.path.exists(about_path):
            continue

        try:
            tree = etree.parse(about_path)
            mod_name = tree.findtext(".//name")
        except Exception:
            continue

        style_patches = {}

        for root, dirs, _ in os.walk(mod_path):
            for d in dirs:
                if d != "Defs":
                    continue
                defs_path = os.path.join(root, d)

                for dirpath, _, files in os.walk(defs_path):
                    for file in files:
                        if not file.endswith(".xml"):
                            continue
                        xml_path = os.path.join(dirpath, file)
                        try:
                            xml_tree = etree.parse(xml_path)
                            for style_def in xml_tree.xpath("//StyleCategoryDef"):
                                def_name = style_def.findtext("defName")
                                if not def_name or def_name in seen_def_names:
                                    continue

                                # Track only if any Sculpture* match is found
                                thing_style_pairs = style_def.find("thingDefStyles")
                                if thing_style_pairs is None:
                                    continue

                                matched_sizes = []
                                for li in thing_style_pairs.findall("li"):
                                    thing_def = li.findtext("thingDef")
                                    style_def_name = li.findtext("styleDef")
                                    for size in sculpture_sizes:
                                        if thing_def == f"Sculpture{size}" and style_def_name == f"{def_name}_Sculpture{size}":
                                            matched_sizes.append(size)

                                if matched_sizes:
                                    seen_def_names.add(def_name)
                                    style_patches[def_name] = matched_sizes
                        except Exception:
                            continue

        if style_patches:
            mods_with_styles.append((mod_name, style_patches))

    return mods_with_styles

def generate_patch_operation(mod_name, def_size_map):
    operations = ""
    for def_name, sizes in def_size_map.items():
        for size in sizes:
            xpath = f'/Defs/StyleCategoryDef[defName="{def_name}"]/thingDefStyles'
            operations += f"""
      <li Class="PatchOperationAdd">
        <xpath>{xpath}</xpath>
        <value>
          <li>
            <thingDef>PropagandaSculpture{size}</thingDef>
            <styleDef>{def_name}_Sculpture{size}</styleDef>
          </li>
        </value>
      </li>"""

    return f"""
  <Operation Class="PatchOperationFindMod">
    <mods>
      <li>{mod_name}</li>
    </mods>
    <match Class="PatchOperationSequence">
      <operations>{operations}
      </operations>
    </match>
  </Operation>"""


def main():
    mods = find_styles_in_mods(MODS_FOLDER)
    patch_content = ""

    for mod_name, def_names in mods:
        patch_content += generate_patch_operation(mod_name, def_names)

    os.makedirs(os.path.dirname(OUTPUT_FILE), exist_ok=True)

    with open(OUTPUT_FILE, "w", encoding="utf-8") as f:
        f.write('<?xml version="1.0" encoding="utf-8"?>\n<Patch>')
        f.write(patch_content)
        f.write("\n</Patch>")

    print(f"✅ Patch file generated at: {OUTPUT_FILE}")


if __name__ == "__main__":
    main()
