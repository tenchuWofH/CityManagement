import axios from 'axios';

export default axios.create({
  // baseUrl: "http://localhost:8080/api",
  baseURL: 'https://localhost:44347',

  headers: {
    'Content-type': 'application/json',
    // 'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Origin': 'https://localhost:44347/',
    'Access-Control-Allow-Headers': 'X-Requested-With,Content-Type',
    'Access-Control-Allow-Methods': 'PUT,POST,GET,DELETE,OPTIONS',
    // config.headers['Access-Control-Allow-Origin'] = '*'
    // config.headers['Access-Control-Allow-Headers'] = 'X-Requested-With,Content-Type'
    // config.headers['Access-Control-Allow-Methods'] = 'PUT,POST,GET,DELETE,OPTIONS'
  },
});
