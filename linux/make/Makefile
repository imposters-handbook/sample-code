JS_FILES=src/app.js
DIST=dist
TODAY=$(shell date +%Y-%B-%d)
TIMESTAMP="//Created at $(TODAY) \n\n"

all: dist app.js

dist:
	@ mkdir -p $(DIST)

app.js:
  @ echo $(TIMESTAMP) > $(DIST)/$@
  @ cat $(JS_FILES) >> $(DIST)/$@

clean:
	@ rm -rf $(DIST)

.PHONY: all clean


###################### Step 1

all:

clean:

.PHONY: all clean


###################### Step 2
all:
	mkdir -p dist
	cp app.js dist/app.js

clean:
	rm -rf dist

.PHONY: all clean

###################### Step 3
all:
	@ mkdir -p dist
	@ cp app.js dist/app.js

clean:
	@ rm -rf dist

.PHONY: all clean

###################### Step 4
all: dist app.js

dist:
	@ mkdir -p dist

app.js:
	@ cp src/app.js dist/app.js

clean:
	@ rm -rf dist

.PHONY: all clean


###################### Step 4.5
# all: dist app.js
#
# dist:
# 	@ mkdir -p $@
#
# app.js:
# 	@ cp src/app.js dist/app.js
#
# clean:
# 	@ rm -rf dist
#
# .PHONY: all clean


###################### Step 5
JS_FILES=src/app.js
DIST=dist
TODAY=$(shell date +%Y-%B-%d)
TIMESTAMP="//Created at $(TODAY) \n\n"

all: dist app.js

dist:
	@ mkdir -p $@

app.js:
  @ echo $(TIMESTAMP) > $(DIST)/$@
  @ cat $(JS_FILES) >> $(DIST)/$@

clean:
	@ rm -rf $(DIST)

.PHONY: all clean

###################### Final
JS_FILES=src/app.js
DIST=dist
TODAY=$(shell date +%Y-%B-%d)
TIMESTAMP="//Created at $(TODAY) \n\n"

all: $(DIST) app.js

$(DIST):
	@ mkdir -p $@

app.js:
	@ echo $(TIMESTAMP) > $(DIST)/$@
	@ cat $(JS_FILES) >> $(DIST)/$@


clean:
	@ rm -rf $(DIST)

.PHONY: all clean
