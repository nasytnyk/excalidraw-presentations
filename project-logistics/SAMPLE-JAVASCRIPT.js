
$.getJSON('/Cargo/AllGrid', function (data) { // Entire graph
    var vm = ko.mapping.fromJS(data);   // All observable
    ko.applyBindings(vm);               // All rows in DOM
});





self.rows = ko.observableArray([]); // Only current page rows

self.load = function () {
    $.getJSON('/Cargo/Grid', { page: self.page(), size: self.size }, function (data) {
        var rows = data.rows.map(function (row) {
            return {
                RefNum: row.RefNum,             
                Origin: row.Origin,             
                Note:   ko.observable(row.Note) // Observable only where editable
            };
        });
        self.rows(rows); // Previous 50 rows are disposed
    });
};

