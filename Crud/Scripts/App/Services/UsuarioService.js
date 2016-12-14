(function () {
    console.log("UsuarioService")
    angular.module("app").service("Usuarios", [
        "$http",
        UsuariosService
    ]);

    function UsuariosService($http) {
        var url;

        this.consultar = function () {
            return $http.get("Usuario/Consultar");
        }

        this.porId = function (usuario) {
            var response = $http({
                method: "post",
                url: "Usuario/PorId",
                params: {
                    idUsuario: JSON.stringify(usuario.idUsuario)
                }
            });
            return response;
        }

        this.salvar = function (usuario) {
            var response;
            if (!usuario.idUsuario) {
                response = $http({
                    method: "post",
                    url: "Usuario/Salvar",
                    data: JSON.stringify(usuario),
                    dataType: "json"
                });
            } else {
                response = $http({
                    method: "post",
                    url: "Usuario/Atualizar",
                    data: JSON.stringify(usuario),
                    dataType: "json"
                });
            }
            return response;
        }

        this.deletar = function (usuario) {
            var response = $http({
                method: "post",
                url: "Usuario/Deletar",
                params: {
                    idUsuario: JSON.stringify(usuario.idUsuario)
                }
            });
            return response;
        }
    }
}());