class ProjectMap {
    constructor(mapId) {
        // Initialize map.
        this._initialize(mapId)
    }

    _initialize = (mapId) => {
        this.markers = [];
        if (!mapId) {
            console.error('Map id cannot be null.');
            return;
        }
        this.map = L.map(mapId)
            .setView([36.47251225396844, 52.35122680664063], 10);
        if (!this.map) {
            console.log('Map element was not found in DOM!');
            return;
        }
        this.zoomAlert = document.getElementById('map-zoom-alert');
        // Prepare map view.
        L.tileLayer("https://tile.openstreetmap.org/{z}/{x}/{y}.png", {
            maxZoom: 18,
            minZoom: 6,
        }).addTo(this.map);

        // Prepare event listeners.
        this._prepareEventListeners();
    }
    _prepareEventListeners = () => {
        // Map click marker.
        this.map.on('click', this._setMarkOnMapEventHandler);
    }
    _setMarkOnMapEventHandler = (e) => {
        if (e.sourceTarget._zoom < 15) {
            this._showZoomAlert('لطفا نقشه را بزرگنمایی کنید.');
            return;
        }
        // Remove another markers.
        this.markers.forEach((marker) => {
            this.map.removeControl(marker);
        })
        this._setMarkOnMap(e.latlng.lat, e.latlng.lng);
    }
    _setMarkOnMap = (lat, lng) => {
        // Add new marker to map.
        var marker = L.marker([lat, lng]).addTo(this.map);
        this.markers.push(marker);
        // Set latlng to inputs.
        if (this.latitudeInput)
            this.latitudeInput.value = lat;
        if (this.longitudeInput)
            this.longitudeInput.value = lng;
    }
    _showZoomAlert = () => {
        this.zoomAlert.classList.remove('hide');
        this.zoomAlert.classList.add('show');
        setTimeout(() => {
            this.zoomAlert.classList.remove('show');
            this.zoomAlert.classList.add('hide');
        }, 3000);
    }

    setupLatitude = (lat) => {
        this.latitudeInput = document.getElementById(lat);
    }
    setupLongitude = (lng) => {
        this.longitudeInput = document.getElementById(lng);
    }
    addMarker = (lat, lng) => {
        this._setMarkOnMap(lat, lng);
    }
}