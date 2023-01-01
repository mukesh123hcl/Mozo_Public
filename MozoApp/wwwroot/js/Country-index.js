(function ($) {
    function Country() {
        var $this = this;

        function initilizeModel() {           
            $("#modal-action-country").on('loaded.bs.modal', function (e) {               
                }).on('hidden.bs.modal', function (e) {                   
                    $(this).removeData('bs.modal');
                });            
        }       
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new Country();
        self.init();        
    })
}(jQuery))
