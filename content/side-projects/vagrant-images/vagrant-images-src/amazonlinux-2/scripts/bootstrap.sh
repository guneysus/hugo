#!/usr/bin/env bash
set -x

yum install -y yum-utils \
  device-mapper-persistent-data \
  lvm2

yum-config-manager \
    --add-repo \
    https://download.docker.com/linux/centos/docker-ce.repo  

yum install -y container-selinux
yum install -y docker-ce docker-ce-cli containerd.io