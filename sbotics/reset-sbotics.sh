#!/bin/bash
echo "Fechando sBotics..."
killall -9 sbotics 2>/dev/null
sleep 1
echo "Limpando dados do usuario..."
rm -f ~/sBotics/Launcher/data/User.aes
echo "Pronto! Abra o sBotics e faca login novamente."
