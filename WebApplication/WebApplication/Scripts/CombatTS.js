//$(document).ready(function () {
//    $.ajax({
//        type: "GET",
//        url: "/Combat",
//        data: {},
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (success) {
//            let list: CombatTS[] = success as CombatTS[];
//            $.each(success, function (index, element) {
//                let character: CombatTS = new CombatTS(element.IdHouseAttack, element.IdHouseDefense, element.NbUniteAttack, element.NbUniteDefense);
//                list.push(character);
//            });
//            list.forEach(function (element: CombatTS) {
//                $('#div_list_character_ts').append(element.afficherCombat);
//            });
//        },
//        error: function (error) {
//            alert(error);
//        }
//    });
//});
var CombatTS = /** @class */ (function () {
    function CombatTS(IdHouseAttack, IdHouseDefense) {
        this.listIdHeroDefense = new Array();
        this.listHeroSoins = new Array();
        this.IdHouseAttack = IdHouseAttack;
        this.IdHouseDefense = IdHouseDefense;
    }
    CombatTS.prototype.afficherCombat = function () {
        /*let myThis: CombatTS = this;
        let div: JQuery = $('<div>' + this.Name + '</div>');
        div[0].onclick = function (e) {
            myThis.openInfoCharacter();
        }
        return div;*/
        return null;
    };
    CombatTS.listCombat = new Array();
    return CombatTS;
}());
//# sourceMappingURL=CombatTS.js.map