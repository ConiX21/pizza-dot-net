var PizzaController = (function () {

    function PizzaController() {
        $("table tbody").on("click", ".btn.btn-primary.detail", function () {
            GetDetail($(this).attr("data-pizza-id"));
        });
    }

    function GetDetail(id) {
        $.get('/Pizza/Detail/' + id)
            .then(function (data) {
                $(".container-modal").html(data);
                $('#modalPizza').modal('show');
            });
    }

    return PizzaController;

})();

var pizzaController = new PizzaController();