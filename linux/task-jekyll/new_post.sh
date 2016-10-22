function new_post(){
    cd ~/sites/conery-io/_posts
    SLUGIFIED="$(echo -n "$1" | sed -e 's/[^[:alnum:]]/-/g' | tr -s '-' | tr A-Z a-z)"
    SLUG=$(date +"%Y-%m-%d"-$SLUGIFIED.md)

    cat <<front_matter > $SLUG
---
layout: post-minimal
title: '$1'
image: ''
comments: false
categories:
summary: ''
---

## Be Brilliant
front_matter
  cd ../
  subl .
}
