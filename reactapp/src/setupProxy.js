const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function (app) {
    app.use(
        ['/home'],
        createProxyMiddleware({
            target: 'https://localhost:7025',
            secure: false,
            changeOrigin: true
        })
    );
};
