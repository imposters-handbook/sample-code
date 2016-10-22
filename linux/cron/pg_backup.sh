BACKUP_DIRECTORY="/home/rob/backups"

# Date stamp (formated YYYYMMDD)
# just used in file name
CURRENT_DATE=$(date "+%Y%m%d")

# !!! Important pg_dump command does not export users/groups tables
# still need to maintain a pg_dumpall for full disaster recovery !!!

# this checks to see if the first command line argument is null
if [ -z "$1" ]
then
# No database specified, do a full backup using pg_dumpall
pg_dumpall | gzip - > $BACKUP_DIRECTORY/everything_$CURRENT_DATE.bak

else
# Database named (command line argument) use pg_dump for targed backup
pg_dump -d $1 -Fc -f $BACKUP_DIRECTORY/$1_$CURRENT_DATE.bak

fi
