#!/bin/bash
set -e

if (( $# < 3 ))
then
    printf "%b" "Error. Not enough arguments.\n" >&2
    printf "%b" "usage: $0 server env root-password\n" >&2
    exit 1
elif (( $# > 3 ))
then
    printf "%b" "Error. Too many arguments.\n" >&2
    printf "%b" "usage: $0 server env root-password\n" >&2
    exit 2
fi

APP_PWD=$(< /dev/urandom tr -dc _A-Z-a-z-0-9\+- | head -c16)
MIG_PWD=$(< /dev/urandom tr -dc _A-Z-a-z-0-9\+- | head -c16)

ansible-playbook --become-user=pi --become -i $1, -e ansible_python_interpreter=/usr/bin/python3 -e env=$2 -e root_pass=$3 -e application_user_password=$APP_PWD -e migration_user_password=$MIG_PWD  -u pi setup-database.yml

echo "Application password is:$APP_PWD"
echo "Migratin password is:$MIG_PWD"