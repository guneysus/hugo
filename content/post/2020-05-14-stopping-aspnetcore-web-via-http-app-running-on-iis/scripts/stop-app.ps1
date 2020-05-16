# pip install httpie
# http POST :19890/iisintegration MS-ASPNETCORE-EVENT:shutdown MS-ASPNETCORE-TOKEN:04e9fbd1-32e2-41f3-92b9-7b560ffa1348

# or
Invoke-WebRequest -Uri http://127.0.0.1:19890/iisintegration `
  -Method POST `
  -Headers @{"MS-ASPNETCORE-EVENT"="shutdown"; "MS-ASPNETCORE-TOKEN"="04e9fbd1-32e2-41f3-92b9-7b560ffa1348"}