self.addEventListener('install', event => {
    console.log('Service Worker installing.');
    self.skipWaiting();
});

self.addEventListener('activate', event => {
    console.log('Service Worker activating.');
});

// Fetch event'i sadece ağdan yanıt versin (cache yok!)
self.addEventListener('fetch', event => {
    event.respondWith(fetch(event.request));
});