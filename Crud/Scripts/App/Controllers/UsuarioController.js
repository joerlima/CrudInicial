(function () {
    console.log("UsuarioController");
    angular.module("app").controller("UsuarioController", [
        "Usuarios",
        AppController
    ]);

    function AppController(Usuarios) {

        var _self = this;

        _self.usuario = {};

        _self.consultar = function () {
            console.log("consultar");
            Usuarios
                .consultar(_self.filtro)
                .then(function (response) {
                    _self.cadastrados = response.data;
                    _self.limparMensagens();
                })
                .catch(function (response) {
                    _self.erros = response.data;
                })
                ["finally"](function () {
                });
        };

        _self.limparMensagens = function () {
            _self.erros = null;
            _self.info = null;
        };

        _self.modal = {
            deletar: function () {
                Usuarios
                   .deletar(_self.usuario)
                   .then(function (response) {
                       $('#modalDeletarUsuario').modal('hide');
                       _self.info = response.data;
                       _self.consultar();
                   })
                   .catch(function (response) {
                       _self.modal.erros = response.data;
                   })
                   ["finally"](function () {
                   });
            },
            salvar: function () {
                Usuarios
                    .salvar(_self.usuario)
                    .then(function (response) {
                        $('#modalUsuario').modal('hide');
                        _self.info = response.data;
                        _self.consultar();
                    })
                    .catch(function (response) {
                        _self.modal.erros = response.data;
                    })
                    ["finally"](function () {
                    });
            },
        }

        _self.novo = function () {
            _self.usuario = {};
            _self.limparMensagens();
        }

        _self.selecionar = function (usuario) {
            _self.usuario = angular.copy(usuario);
        };

    }
})();