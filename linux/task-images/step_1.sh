#make a directory for our demo
mkdir -p imposter/demos

#move the demo files
#assumes you downloaded to the Desktop,
#adjust path as needed
mv ~/Desktop/task-images ~/imposter/demos

#change into the directory
cd imposter/demos/task-images

#list all images out
ls **/*.jpg **/*.png

#redirect STDOUT to a text file
ls **/*.jpg **/*.png > images.txt
