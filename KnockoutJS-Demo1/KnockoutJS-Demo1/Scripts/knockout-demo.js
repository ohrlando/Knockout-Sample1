var Agenda = (function () {
    _agenda = null;

    return {
        save: function () {
            $.ajax({
                url: "/agenda/save",
                type: "POST",
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(_agenda)
            });
        },

        get agenda() {
            return _agenda;
        },

        prepareModel: function (agenda) {
            _agenda = agenda;
            agenda.newEvento = function (date, eventoNome, obs, estaAtivo) {
                if (typeof(date) !== "string") {
                    date = eventoNome = obs = undefined
                }
                agenda.eventos.push({
                    data: ko.observable(date || new Date().toLocaleString()),
                    eventoNome: ko.observable(eventoNome || ""),
                    obs: ko.observable(obs || ""),
                    estaAtivo: ko.observable(estaAtivo == undefined ? true : estaAtivo)
                });
                return agenda.eventos[agenda.eventos.length - 1];
            };
            agenda.desativar = function (evento) {
                evento.estaAtivo(false);
            }
            agenda.estaAtivo = ko.observable(agenda.estaAtivo);
            agenda.eventos = agenda.eventos.map(function (item) {
                return agenda.newEvento(item.data, item.eventoNome, item.obs, item.estaAtivo);
            });
            agenda.agendaNome = ko.observable("Agenda 1");
            agenda.eventos = ko.observableArray(agenda.eventos);
            agenda.count = ko.computed(function () {
                return agenda.eventos().length;
            });

            return agenda;
        }
    }
})();