###################### Step 1

all:

clean:

.PHONY: all


###################### Step 2

SASS=node_modules/.bin/node-sass
SASS_FILES=assets/sass/main.scss
JS_FILES=assets/js/*.js
UGLIFY=node_modules/.bin/uglifyjs
DIST_CSS=public/css
DIST_JS=public/js

all:

clean:

.PHONY: all


###################### Final
SASS=node_modules/.bin/node-sass
SASS_FILES=assets/sass/main.scss
JS_FILES=assets/js/*.js assets/js/**/*.js
UGLIFY=node_modules/.bin/uglifyjs
DIST_CSS=public/css
DIST_JS=public/js

all: dist app.css app.js

dist:
	mkdir $(DIST_CSS) $(DIST_JS)

app.css:
	@ $(SASS) --output-style compressed $(SASS_FILES) > $(DIST_CSS)/$@

app.js:
	@ cat $(JS_FILES) | $(UGLIFY) > $(DIST_JS)/$@

clean:
	@rm -rf $(DIST_CSS) $(DIST_JS)

.PHONY: all
