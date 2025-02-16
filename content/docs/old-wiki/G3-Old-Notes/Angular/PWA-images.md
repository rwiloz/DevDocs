
# Generate PWA Images

## Install this

```npm install --global pwa-asset-generator```

## Run this

Assuming logo.png has been created

```npx pwa-asset-generator ./src/logo.png ./src/assets/pwa -p 0 -m ./src/manifest.webmanifest -i ./src/index.html -t png```

Reference
https://github.com/onderceylan/pwa-asset-generator#readme

---

Portsmouth example

```npx pwa-asset-generator ./src/assets/images/logo/logo.svg ./src/assets/pwa -p 10% -m ./src/manifest.webmanifest -i ./src/index.html -t png -b #fff```