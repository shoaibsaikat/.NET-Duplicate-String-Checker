# Duplicate-String-Checker
Compares two Tizen translation(*.po) files and returns the key strings(msgid) that are present in "Reference file" but not found in "Compare file".

For example, in "Example files" folder there are two .po files,
the programe will return the key strings that are not found at b.po file but present in a.po file, if a.po is considered as reference file.

Note: Here I've tested two *.po files with line that starts with "msgid" string.
For personal use someone has to change these parameters accordingly.
