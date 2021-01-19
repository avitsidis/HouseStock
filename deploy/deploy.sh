#!/bin/bash
set -e

if (( $# < 4 ))
then
    printf "%b" "Error. Not enough arguments.\n" >&2
    printf "%b" "usage: $0 server env version db_password\n" >&2
    exit 1
elif (( $# > 4 ))
then
    printf "%b" "Error. Too many arguments.\n" >&2
    printf "%b" "usage: $0 server env version db_password\n" >&2
    exit 2
fi

ansible-playbook --become-user=pi --become -i $1, -e ansible_python_interpreter=/usr/bin/python3 -e env=$2 -e version=$3 -e db_password=$4 -u pi deploy.yml