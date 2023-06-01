if ($("#google-map").length) {
      function initialize() {
         var mapOptions = {
            zoom: 13.01,
            scrollwheel: false,
            styles: [
                {
                    "featureType": "administrative.land_parcel",
                    "elementType": "labels",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "poi",
                    "elementType": "labels.text",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "poi.business",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "poi.park",
                    "elementType": "labels.text",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road.local",
                    "elementType": "labels",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                }
            ],
           
            /* --Add your Location here-- */
            center: new google.maps.LatLng(47.6685596,-122.1611609)
         };
         var map = new google.maps.Map(document.getElementById('google-map'),
            mapOptions);
         var marker = new google.maps.Marker({
            position: map.getCenter(),
            /* Map Marker if you want to add custom icon */
            // icon: 'images/pin.png',
            map: map
         });
      }
      google.maps.event.addDomListener(window, 'load', initialize);
}