curl -X 'GET' \
  'http://localhost:50001/api/Items' \
  -H 'accept: text/plain'

curl -X 'POST' \
  'http://localhost:50001/api/Items' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": "222",
  "name": "Test Name",
  "description": "Test Descr"
}'
