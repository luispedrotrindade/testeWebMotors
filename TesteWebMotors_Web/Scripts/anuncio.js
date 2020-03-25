$("#btnAddAnuncio").on("click", function () {

    $("#Id").val("");
    $("#Model").val("");
    $("#QtdPassengers").val("");
    $("#CreationDate").val("");

    $(".formFields").show("slow");
    $(this).hide();
});


function onSubmit() {
    if ($("#Id").val()) {
        this._anuncio.Model = $("#Model").val();
        this._anuncio.QtdPassengers = $("#QtdPassengers").val();


        if (this._anuncio.Model && this._anuncio.QtdPassengers) {
            var anuncio = new anuncio(this._anuncio.Id, this._anuncio.Model, parseInt(this._anuncio.QtdPassengers.toString()), this._anuncio.CreationDate);
            this.dataService.updateAnuncio(anuncio).subscribe(
                data => this.ngOnInit(),
                error => console.error('Error', error));
        }
    }
    else {
        this._anuncio = data;
        if (this._anuncio.Model && this._anuncio.QtdPassengers) {
            var anuncio = new anuncio(0, this._anuncio.Model, parseInt(this._anuncio.QtdPassengers.toString()), null);
            this.dataService.createAnuncio(anuncio).subscribe(
                data => this.ngOnInit(),
                error => console.error('Error', error));
        }
    }
    $(".formFields").hide("slow");
    $("#btnAddAnuncio").show();
}
function showData(data) {
    $("#formFields").show("slow");
    $("#Id").val(data.id);
    $("#Model").val(data.model);
    $("#QtdPassengers").val(data.qtdPassengers);
    $("#CreationDate").val(data.creationDate);

    this._anuncio.Id = data.id;
    this._anuncio.Model = data.model;
    this._anuncio.QtdPassengers = data.qtdPassengers;
    this._anuncio.CreationDate = data.creationDate;

}

function onEditAnuncio(anuncio) {
    this.dataService.getAnuncio(anuncio.id).subscribe(
        data => this.showData(data),
        error => console.error('Error', error)
    );
}

function onDeleteAnuncio(anuncio) {
    var result = confirm("Tem certeza que deseja excluir esse registro?");
    if (result) {
        this.dataService.deleteAnuncio(anuncio.id).subscribe(
            data => this.ngOnInit(),
            error => console.error('Error', error)
        );
    }
}

