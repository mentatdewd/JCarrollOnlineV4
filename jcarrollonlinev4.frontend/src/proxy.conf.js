const PROXY_CONFIG = [
  {
    context: [
      "/api/userinfo",
    ],
    target: "https://localhost:7029",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
