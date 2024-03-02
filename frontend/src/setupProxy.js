const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = 'http://localhost:5050';

const context = [
  "/api"
];

module.exports = function (app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  });
  app.use(appProxy);
}