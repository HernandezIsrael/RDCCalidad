$('.datetimepicker').datetimepicker({
    defaultDate: Date.now(),

    format: 'DD-MM-YYYY',
    icons: {


        time: "fa fa-clock-o",
        date: "fa fa-calendar",
        up: "fa fa-chevron-up",
        down: "fa fa-chevron-down",
        previous: 'fa fa-chevron-left',
        next: 'fa fa-chevron-right',
        today: 'fa fa-screenshot',
        clear: 'fa fa-trash',
        close: 'fa fa-remove'

    }
});
function TDoctos(Url,v) {
    $.ajax({
        cache: false,
        async: true,
        type: "GET",
        url: Url,
        data: { id: v },
        success: function (response) {

            $('#Tdocos').html('');
            try {
                $('#Tdocos').html(response);
               
            } catch (err) { }
        }
    });
    return false;
}
function SubirConcepto(Url,v) {

    $.ajax({
        cache: false,
        async: true,
        type: "GET",
        url: Url,
        data: { id: v },
        success: function (response) {

            $('#GVConceptos').html('');
            try {
                $('#GVConceptos').html(response);

            } catch (err) { }
        }
    });
    return false;
}
function Subir(URL) {

    $('#txtUploadFile').on('change', function (e) {
      
        var files = e.target.files;
        
        var myID = +$("#Id_Tipo_Documento").val();
        if (files.length > 0) {
            if (window.FormData !== undefined) {
                var data = new FormData();
                for (var x = 0; x < files.length; x++) {
                    console.log(files);
                    data.append(files[x].name, files[x]);
                }
                if ($("#Id_Tipo_Documento").val() != -1) {
                  
                $.ajax({
                    type: "POST",
                    url: URL + '?Id_Tipo_Documento=' + myID,
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        //console.log(result);
                        try {
                            $('#txtUploadFile').val('');
                            $("#Id_Tipo_Documento").val(-1);
                            LlamarDoctos();
                            swal({
                                type: 'success',
                                title: 'Listo',
                                text: 'Documento cargado',
                                timer: 2000,
                                showCloseButton: false,
                                showConfirmButton: false
                            });
                        } catch (err) { }
                    },
                    error: function (xhr, status, p3, p4) {
                        var err = "Error " + " " + status + " " + p3 + " " + p4;
                        if (xhr.responseText && xhr.responseText[0] == "{")
                            err = JSON.parse(xhr.responseText).Message;
                        console.log(err);
                        try {
                            swal({
                                type: 'error',
                                title: 'Oops...',
                                text: 'Error al subir el archivo',
                                timer: 2000,
                                showCloseButton: false,
                                showConfirmButton: false
                            });
                        } catch (err) {
                        }
                    }
                });
                } else {
                    try {
                        swal({
                            type: 'error',
                            title: 'Oops...',
                            text: 'Seleccionar tipo de documento',
                            timer: 2000,
                            showCloseButton: false,
                            showConfirmButton: false
                        });
                        $('#txtUploadFile').val('');
                    } catch (err) {
                    }
                }
            } else {
                alert("This browser doesn't support HTML5 file uploads!");
            }
        }
        return false;
    });
}
function CallProjects(Url) {
    $("#Id_Empresa").change(function () {
        $("#Id_Proyecto").empty();
        $("#Id_Rubro").empty();
        $("#Id_Proveedor").empty();
        $("#Id_Banco").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idemp: $("#Id_Empresa").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_Proyecto").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Proyecto").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });
}
function CallRubros(Url) {
    $("#Id_Proyecto").change(function () {
        $("#Id_Rubro").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { id: $("#Id_Proyecto").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_Rubro").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Rubro").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });
}
function CallProveedores(Url) {
    $("#Id_Empresa").change(function () {
        $("#Id_Proveedor").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { id: $("#Id_Empresa").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_Proveedor").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Proveedor").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });
}
function CallBankPro(Url) {
    $("#Id_Proveedor").change(function () {
        $("#Id_Banco").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { id: $("#Id_Proveedor").val(), idmoneda: $("#Id_Moneda").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_Banco").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Banco").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });

    $("#Id_Moneda").change(function () {
        $("#Id_Banco").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { id: $("#Id_Proveedor").val(), idmoneda: $("#Id_Moneda").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_Banco").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Banco").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });

}
function CallClabePro(Url) {
    $("#Id_Proveedor").change(function () {
        $("#Id_Clabe").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: {idbanco:$("#Id_Banco").val(), idproveedor:$("#Id_Proveedor").val(), idmoneda: $("#Id_Moneda").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_Clabe").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Clabe").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });
    $("#Id_Banco").change(function () {
        $("#Id_Clabe").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idbanco: $("#Id_Banco").val(), idproveedor: $("#Id_Proveedor").val(), idmoneda: $("#Id_Moneda").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_Clabe").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Clabe").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });
    $("#Id_Moneda").change(function () {
        $("#Id_Clabe").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idbanco: $("#Id_Banco").val(), idproveedor: $("#Id_Proveedor").val(), idmoneda: $("#Id_Moneda").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_Clabe").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Clabe").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });

}
function CallCuentaPro(Url) {
    $("#Id_Proveedor").change(function () {
        $("#Id_N_Cuenta").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idbanco: $("#Id_Banco").val(), idproveedor: $("#Id_Proveedor").val(), idmoneda: $("#Id_Moneda").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_N_Cuenta").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_N_Cuenta").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });
    $("#Id_Banco").change(function () {
        $("#Id_N_Cuenta").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idbanco: $("#Id_Banco").val(), idproveedor: $("#Id_Proveedor").val(), idmoneda: $("#Id_Moneda").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_N_Cuenta").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_N_Cuenta").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });
    $("#Id_Moneda").change(function () {
        $("#Id_N_Cuenta").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idbanco: $("#Id_Banco").val(), idproveedor: $("#Id_Proveedor").val(), idmoneda: $("#Id_Moneda").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_N_Cuenta").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_N_Cuenta").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });

}
function CallContrato(Url) {
    $("#Id_Empresa").change(function () {
        $("#Id_Contrato").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idempresa: $("#Id_Empresa").val(), idproveedor: $("#Id_Proveedor").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_Contrato").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Contrato").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });
    $("#Id_Proveedor").change(function () {
        $("#Id_Contrato").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idempresa: $("#Id_Empresa").val(), idproveedor: $("#Id_Proveedor").val() },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == -1) {
                        $("#Id_Contrato").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Contrato").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    });
}
function Sumatoria() {
  
    $("#Importe_Total").change(function () {
        var importe = 0;
        importe = Number($('#Importe_Total').val());
        var iva = 0;
        iva = Number($('#IVA').val());
        var riva = 0;
        riva = Number($('#Retenciones').val());
        var isr = 0;
        isr = Number($('#ISR').val());
        var otros = 0;
        otros = Number($('#Otros').val());
        var total = 0;
        total = importe + iva - riva - isr - otros;
      
        $('#Total').val(total);
    });
    $("#IVA").change(function () {
        var importe = 0;
        importe = Number($('#Importe_Total').val());
        var iva = 0;
        iva = Number($('#IVA').val());
        var riva = 0;
        riva = Number($('#Retenciones').val());
        var isr = 0;
        isr = Number($('#ISR').val());
        var otros = 0;
        otros = Number($('#Otros').val());
        var total = 0;
        total = importe + iva - riva - isr - otros;
      
        $('#Total').val(total);
    });
    $("#Retenciones").change(function () {
        var importe = 0;
        importe = Number($('#Importe_Total').val());
        var iva = 0;
        iva = Number($('#IVA').val());
        var riva = 0;
        riva = Number($('#Retenciones').val());
        var isr = 0;
        isr = Number($('#ISR').val());
        var otros = 0;
        otros = Number($('#Otros').val());
        var total = 0;
        total = importe + iva - riva - isr - otros;
       
        $('#Total').val(total);
    });
    $("#ISR").change(function () {
        var importe = 0;
        importe = Number($('#Importe_Total').val());
        var iva = 0;
        iva = Number($('#IVA').val());
        var riva = 0;
        riva = Number($('#Retenciones').val());
        var isr = 0;
        isr = Number($('#ISR').val());
        var otros = 0;
        otros = Number($('#Otros').val());
        var total = 0;
        total = importe + iva - riva - isr - otros;
       
        $('#Total').val(total);
    });
    $("#Otros").change(function () {
        var importe = 0;
        importe = Number($('#Importe_Total').val());
        var iva = 0;
        iva = Number($('#IVA').val());
        var riva = 0;
        riva = Number($('#Retenciones').val());
        var isr = 0;
        isr = Number($('#ISR').val());
        var otros = 0;
        otros = Number($('#Otros').val());
        var total = 0;
        total = importe + iva - riva - isr - otros;
       
        $('#Total').val(total);
    });
}
function onBegin(respuesta) {
    console.log(respuesta + 'Bg');
}
function onSuccess(respuesta) {
    console.log(respuesta + 'Sc');
}
function onComplete(respuesta) {
  
}
function onFailure(respuesta) {
    console.log(respuesta + 'Fl');
}
function SendConptos(Url) {
    $('#btnconceptos').click(function () {
        var value = $("#Id_Pago").val();
        var concept = $("#Conceptos1").val();
        var data = { concep: concept, idpago: value };
        $.post(Url, data, function (data) {
           
            LlamarConceptos();
            $("#Conceptos1").val('');
        });
        return false;
    });
}
function MsjError(list){
    //swal({
        
        
    //    html: list,
    //    list,
    //    showCloseButton: true
    //});
    $.notify({
        icon: "add_alert",
        message: "Welcome to <b>Material Dashboard Pro</b> - a beautiful freebie for every web developer."

    }, {
        type: 'success',
        timer: 4000,
        placement: {
            from: from,
            align: align
        }
    });
}




function EditCallProjects(Url,v,p) {
    if (v!= -1){
        $("#Id_Proyecto").empty();
        $("#Id_Rubro").empty();
        $("#Id_Proveedor").empty();
        $("#Id_Banco").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idemp:v },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value ==p) {
                        $("#Id_Proyecto").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Proyecto").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }
                    

                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };
}
function EditCallRubros(Url,v,r) {
    if(v!=-1) {
        $("#Id_Rubro").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { id: v },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value ==r) {
                        $("#Id_Rubro").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Rubro").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };
}
function EditCallProveedores(Url,v,p) {
    if(v!=-1) {
        $("#Id_Proveedor").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { id: v },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == p) {
                        $("#Id_Proveedor").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Proveedor").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };
}
function EditCallBankPro(Url,v,m,b) {
    if(v!=-1){
        $("#Id_Banco").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { id: v, idmoneda: m },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value ==b) {
                        $("#Id_Banco").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Banco").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };

    if(m!=-1) {
        $("#Id_Banco").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { id: v, idmoneda:m },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value ==b) {
                        $("#Id_Banco").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Banco").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };

}
function EditCallClabePro(Url,v,p,m,c) {
    if(p!=-1){
        $("#Id_Clabe").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idbanco:v, idproveedor: p, idmoneda: m },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == c) {
                        $("#Id_Clabe").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Clabe").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };
    if(v!=-1) {
        $("#Id_Clabe").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idbanco: v, idproveedor: p, idmoneda: m },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == c) {
                        $("#Id_Clabe").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Clabe").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };
   if(m!=-1){
        $("#Id_Clabe").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idbanco: v, idproveedor: p, idmoneda: m },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == c) {
                        $("#Id_Clabe").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Clabe").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };

}
function EditCallCuentaPro(Url,b,p,m,n) {
    if(p!=-1) {
        $("#Id_N_Cuenta").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idbanco:b, idproveedor: p, idmoneda: m },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == n) {
                        $("#Id_N_Cuenta").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_N_Cuenta").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };
    if (b != -1) {
        $("#Id_N_Cuenta").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idbanco: b, idproveedor: p, idmoneda: m },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == n) {
                        $("#Id_N_Cuenta").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_N_Cuenta").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };
   if( m!=-1) {
        $("#Id_N_Cuenta").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idbanco: b, idproveedor: p, idmoneda: m },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == n) {
                        $("#Id_N_Cuenta").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_N_Cuenta").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };

}
function EditCallContrato(Url,e,p,c) {
    if(e!=-1) {
        $("#Id_Contrato").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idempresa: e, idproveedor: p },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == c) {
                        $("#Id_Contrato").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Contrato").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };
    if(p!=-1){
        $("#Id_Contrato").empty();
        $.ajax({
            type: 'POST',
            url: Url,

            dataType: 'json',

            data: { idempresa: e, idproveedor: p },
            success: function (states) {

                $.each(states, function (i, state) {


                    if (state.Value == c) {
                        $("#Id_Contrato").append('<option selected = "selected" value="' + state.Value + '">' +
                         state.Text + '</option>');


                    } else {
                        $("#Id_Contrato").append('<option value="' + state.Value + '">' +
                             state.Text + '</option>');
                    }


                });
            },
            error: function (ex) {
                alert('Failed to retrieve .' + ex);
            }
        });

        return false;
    };
}
