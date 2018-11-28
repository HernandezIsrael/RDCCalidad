CustomGlobal = {
    showNotificationStyle: function(from, align, materialIcon, style, sender, yourHeader, yourMessage, yourURL, yourTarget) {

        // Colors: '', 'info', 'success', 'warning', 'danger', 'rose', 'primary'

        $.notify({
            icon: materialIcon,
            title: "<h6><strong>" + sender + "</strong></h6>",
            message: "<h6>" + yourHeader + "</h6><p>" + yourMessage + "</p>",
            url: yourURL,
            target: yourTarget

        }, {
                type: style,
                timer: 3000,
                placement: {
                    from: from,
                    align: align
                },
                newest_on_top: true
            });
    }
}