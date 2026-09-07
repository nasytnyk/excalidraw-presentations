# Use this bash script to create 112px renders in "112" subdirectory

mkdir -p 112 && for f in *.png; do [ -f "$f" ] && convert "$f" -filter Lanczos -resize 112x "112/$f" && optipng -o2 "112/$f"; done