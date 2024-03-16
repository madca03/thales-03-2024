const { createProxyMiddleware } = require('http-proxy-middleware');

const target = 'http://localhost:5050' // backend url

const routesToProxy = [
  "/api"
];

module.exports = function (app) {
  const appProxy = createProxyMiddleware(routesToProxy, {
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-alive"
    }
  });

  app.use(appProxy);
}
