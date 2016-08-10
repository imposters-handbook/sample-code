JS_FILES=src/app.js
DIST=dist
TODAY=$(shell date +%Y-%B-%d)
TIMESTAMP="//Created at $(TODAY) \n\n"

all: dist app.js

dist:
	@ mkdir $@

app.js:
	@ echo $(TIMESTAMP) > $(DIST)/$@
	@ cat $(JS_FILES) >> $(DIST)/$@


clean:
	@ rm -rf $(DIST)

.PHONY: all clean
