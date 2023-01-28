# install mono
## Add the Mono repository to your system
sudo apt-get install -y gnupg ca-certificates
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo deb "https://download.mono-project.com/repo/ubuntu stable-focal main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list
sudo apt-get update
## Install Mono
sudo apt-get install -y mono-devel=6.12* libgtk2.0-dev

# expand produire
wget -O produire-mono.tar.gz https://rdr.utopiat.net/files/mono/latest.php?type=tar
tar zxvf produire-mono.tar.gz
rm produire-mono.tar.gz
