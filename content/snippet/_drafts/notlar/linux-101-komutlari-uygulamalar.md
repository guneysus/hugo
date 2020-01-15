# UYGULAMALAR

## uygulama kurmak

```shell
apt install vim
sudo apt-get install vim
sudo aptitude install vim
```

## yardım almak

```shell
man ls
ls --help
```

```shell
pwd
cd
ls
mkdir
rmdir
touch
mv
cp
rm
```

## wildcards

```shell
cd /home/ahmed/Downloads
ls *.json
ls -l *.json
ls Invoice*
ls ????.txt
ls [56]* -1
ls ![56]* -1
ls [!56]* -1
```

## standart çıktı komutları

```shell
echo Merhaba
date
echo $(date)
echo `date`

cd /home/ahmed/Desktop/linux-101/uygulama/albumler/rock/teoman
cat gonulcelen.txt
cat on-yedi.txt
cat gonulcelen.txt on-yedi.txt
cat *.txt
```

## network ve internet komutları

```shell
curl http://httpbin.org/ip
curl http://httpbin.org/ip | jq
curl http://httpbin.org/json | jq
curl http://httpbin.org/uuid
curl http://httpbin.org/html

wget http://httpbin.org/robots.txt
```

## aliases

```shell
alias
cd /home/ahmed/workspace/repos/github.com/guneysus/blog

git log --graph --pretty='\''%Cred%h%Creset -%C(yellow)%d%Creset %s %Cgreen(%cr) %C(bold blue)<%an>%Creset'\'' --abbrev-commit'
alias glol='git log --graph --pretty='\''%Cred%h%Creset -%C(yellow)%d%Creset %s %Cgreen(%cr) %C(bold blue)<%an>%Creset'\'' --abbrev-commit'

glol
```

## pipe

```shell
ps -A
ps -A | less

ps -A | sort -g
ps -A | sort -g | less

ps -A | sort -k 4
ps -A | sort -k 4 | less

ps -A | grep opera
ps -A | grep python
```

## biraz eğlenelim
```shell
wget https://git.io/fA2GR -O vedat-milor.txt

cat vedat-milor.txt
cat vedat-milor.txt | grep Vedat
grep Vedat < vedat-milor.txt 

cat vedat-milor.txt | sed 's/Vedat/Ahmed/g'
cat vedat-milor.txt | sed 's/Vedat/Ahmed/g' | grep Ahmed

cat vedat-milor.txt | sed 's/Vedat/Ahmed/g' > ahmed-milor.txt

```

--