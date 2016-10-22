#!/bin/sh
function resize_jpegs(){
	DIST=./dist/$1/

	if [ -d "$DIST" ]; then
		rm -R $DIST
	fi

	mkdir -p $DIST

	for IMG in ./images/$1/*.jpg
	do
		convert $IMG -resize 600x400 "$DIST$(basename $IMG)"
	done
}
