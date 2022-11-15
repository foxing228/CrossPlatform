cd /var/baget/app
sudo kill -9 $(sudo lsof -t -i:5000)
sudo dotnet BaGet.dll --urls http://*:5000