sudo apt-get update
sudo apt-get install -y build-essential git wget curl libssl-dev python-software-properties

apt-get install -y nginx

sh -c 'echo "deb http://apt.postgresql.org/pub/repos/apt/ `lsb_release -cs`-pgdg main" >> /etc/apt/sources.list.d/pgdg.list'
wget -q https://www.postgresql.org/media/keys/ACCC4CF8.asc -O - | sudo apt-key add -
apt-get update
apt-get install -y postgresql postgresql-contrib

curl -sL https://deb.nodesource.com/setup_6.x | sudo -E bash -
sudo apt-get install -y nodejs

npm install -g pm2

adduser deployer
update-alternatives --config editor #choose 3, vim!
visudo
# the visudo command opens up the sudoers file
# so you need to add the new account as below
# just copy what it says for root
#deployer    ALL=(ALL:ALL) ALL

cd /home/deployer
mkdir .ssh
cd .ssh
vim authorized_keys
cat ~/.ssh/id_rsa.pub
chown -R deployer /home/deployer/.ssh

su postgres
cd
psql -c "create role deployer with LOGIN SUPERUSER CREATEROLE CREATEDB password 'MY_PASSWORD';"
exit
