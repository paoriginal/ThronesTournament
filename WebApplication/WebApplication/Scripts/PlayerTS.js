//$(document).ready(function () {
//    $.ajax({
//        type: "GET",
//        url: "/Player",
//        data: {},
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (success) {
//            let list: PlayerTS[] = success as PlayerTS[];
//            $.each(success, function (index, element) {
//                let player: PlayerTS = new PlayerTS(element.IdPlayer, element.Pseudo, element.MyHouse);
//                list.push(player);
//            });
//            list.forEach(function (element: PlayerTS) {
//                $('#div_list_character_ts').append(element.afficherPlayer);
//            });
//        },
//        error: function (error) {
//            alert(error);
//        }
//    });
//});
$(function () {
    var listJoueur = new Array();
    var index = 0;
    for (var _i = 0, _a = HouseTS.listMaison; _i < _a.length; _i++) {
        var house = _a[_i];
        $('#house').append("<option value=\"" + house.IdHouse + "\" > " + house.Name + " </option>");
    }
    $("#creer").click(function () {
        var name = $("#name").val();
        var houseId = $("#house").val();
        var houseName = $("#house option:selected").text();
        $("#name").val('');
        $("#house option[value='" + houseId + "']").remove();
        $("#listJoueur").append("<li value=\"" + houseId + "\">" + name + " - <strong>" + houseName + "</strong></li>");
        for (var _i = 0, _a = HouseTS.listMaison; _i < _a.length; _i++) {
            var house = _a[_i];
            if (house.IdHouse == houseId) {
                listJoueur.push(new PlayerTS(name, house));
            }
        }
        var count = $("#listJoueur li").length;
        if (count >= 2) {
            $("#commencer").prop('disabled', false);
        }
    });
    $("#commencer").click(function () {
        $('#main').empty();
        $('#main').load("/Home/Page2", function (response, status, xhr) {
            if (status == "error") {
                var msg = "Sorry but there was an error: ";
                $("#error").html(msg + xhr.status + " " + xhr.statusText);
            }
            else {
                supprHandler1();
                choixAdversaire();
                defineHandlerPage2();
                $('#listJoueur li').css({ "border-bottom": "1px solid red" });
                $('#listJoueur li').first().css({ "border-bottom": "1px solid green" });
            }
        });
    });
    function supprHandler1() {
        $("#creer").unbind();
        $("#commencer").unbind();
        $("#commencer").unbind();
    }
    function choixAdversaire() {
        $('#div_list_adversaire_ts ul').empty();
        $('#hero table').empty();
        for (var _i = 0, listJoueur_1 = listJoueur; _i < listJoueur_1.length; _i++) {
            var joueur = listJoueur_1[_i];
            if (joueur.IdPlayer != listJoueur[index].IdPlayer) {
                $('#div_list_adversaire_ts ul').append("<div style=\"display:flex;\"><input type=\"checkbox\" class=\"ennemie combat\" value=" + joueur.Maison.IdHouse + "/><li>" + joueur.Maison.Name + "</li></div>");
            }
        }
        $('#hero table').append("<tr><th>Héro</th><th>Soins</th><th>Attaquant</th><th>Defenseur</th></tr>");
        var indexTab = 0;
        for (var _a = 0, _b = listJoueur[index].Maison.listHero; _a < _b.length; _a++) {
            var character = _b[_a];
            $('#hero table').append("<tr><td>" + character.Firstname + " " + character.Name + "</td><td><input class=\"character combat\" id=\"checkBox" + indexTab + "-1\" value=\"" + indexTab + "-1\" type= \"checkbox\" > </td><td> <input class=\"character combat\" id=\"checkBox" + indexTab + "-2\" value=\"" + indexTab + "-2\" type= \"checkbox\" > </td><td> <input class=\"character combat\" id=\"checkBox" + indexTab + "-3\" value=\"" + indexTab + "-3\" type= \"checkbox\" > </td></tr>");
            indexTab++;
        }
        var checkBoxes = $('input.combat');
        checkBoxes.on("customChange", function () {
            var checkBoxesEnnemie = $('input.ennemie:checked').length;
            var checkBoxesCharacter = $('input.character:checked').length;
            var nbAttaquant = $('input.character[value$="-2"]:checked').length;
            if (checkBoxesEnnemie >= 1 && checkBoxesEnnemie <= nbAttaquant && checkBoxesCharacter == listJoueur[index].Maison.listHero.length) {
                $('#suivant').prop("disabled", false);
            }
            else {
                $('#suivant').prop("disabled", true);
            }
        });
        checkBoxes.change(function () {
            var checkBoxesEnnemie = $('input.ennemie:checked').length;
            var checkBoxesCharacter = $('input.character:checked').length;
            var nbAttaquant = $('input.character[value$="-2"]:checked').length;
            if (checkBoxesEnnemie >= 1 && checkBoxesEnnemie <= nbAttaquant && checkBoxesCharacter == listJoueur[index].Maison.listHero.length) {
                $('#suivant').prop("disabled", false);
            }
            else {
                $('#suivant').prop("disabled", true);
            }
        });
    }
    function defineHandlerPage2() {
        $("#suivant").click(function () {
            $('#div_list_adversaire_ts ul input[type="checkbox"]:checked').each(function () {
                CombatTS.listCombat.push(new CombatTS(listJoueur[index].Maison.IdHouse, parseInt($(this).val())));
            });
            $('#hero table').find('input[type="checkbox"]:checked').each(function () {
                var res = $(this).val().split("-");
                listJoueur[index].Maison.listHero[res[0]].Type = parseInt(res[1]);
            });
            index++;
            $('#suivant').prop("disabled", true);
            if (index < listJoueur.length) {
                $('#listJoueur li').css({ "border-bottom": "1px solid red" });
                $('#listJoueur li').eq(index).css({ "border-bottom": "1px solid green" });
                choixAdversaire();
            }
            else {
                $('#main').empty();
                $('#main').load("/Home/Page3", function (response, status, xhr) {
                    if (status == "error") {
                        var msg = "Sorry but there was an error: ";
                        $("#error").html(msg + xhr.status + " " + xhr.statusText);
                    }
                    else {
                        supprHandler2();
                        index = 0;
                        choixUnite();
                        defineHandlerPage3();
                        $('#listJoueur li').css({ "border-bottom": "1px solid red" });
                        $('#listJoueur li').first().css({ "border-bottom": "1px solid green" });
                    }
                });
            }
        });
    }
    function supprHandler2() {
        $("#suivant").unbind();
        $('input.combat').unbind();
    }
    function choixUnite() {
        $('#dispo').val("Hommes et femmes disponible : " + listJoueur[index].Maison.nbUnite);
        $('#attaque').val(listJoueur[index].Maison.nbUnite / 2);
        $('#defense').val(listJoueur[index].Maison.nbUnite / 2);
        $('#attaque').attr("max", listJoueur[index].Maison.nbUnite);
        $('#defense').attr("max", listJoueur[index].Maison.nbUnite);
    }
    function defineHandlerPage3() {
        $("#etape3").click(function () {
            listJoueur[index].Maison.nbAttaquant = $('#attaque').val();
            index++;
            if (index < listJoueur.length) {
                $('#listJoueur li').css({ "border-bottom": "1px solid red" });
                $('#listJoueur li').eq(index).css({ "border-bottom": "1px solid green" });
                choixUnite();
            }
            else {
                $('#main').empty();
                $('#main').load("/Home/Page4", function (response, status, xhr) {
                    if (status == "error") {
                        var msg = "Sorry but there was an error: ";
                        $("#error").html(msg + xhr.status + " " + xhr.statusText);
                    }
                    else {
                        index = 0;
                        supprHandler3();
                        paramAttaque();
                        defineHandlerPage4();
                        $('#listJoueur li').css({ "border-bottom": "1px solid red" });
                        $('#listJoueur li').first().css({ "border-bottom": "1px solid green" });
                    }
                });
            }
        });
    }
    function supprHandler3() {
        $("#etape3").unbind();
    }
    function paramAttaque() {
        $('#tableCombat').empty();
        var i = 0;
        var html = "";
        html += "<tr>";
        var _loop_1 = function (combat) {
            if (combat.IdHouseAttack == listJoueur[index].Maison.IdHouse) {
                var adversaire = HouseTS.listMaison.filter(function (maison) { return maison.IdHouse === combat.IdHouseDefense; });
                html += "<td><label>Combat contre " + adversaire[0].Name + "</label><select id=\"heroCombat-" + combat.IdHouseAttack + "-" + combat.IdHouseDefense + "\"><option>-</option>";
                for (var _i = 0, _a = listJoueur[index].Maison.listHero; _i < _a.length; _i++) {
                    var character = _a[_i];
                    if (character.Type == Fonction.Attaquant) {
                        html += "<option value=\"" + character.IdCharacter + "\">" + character.Firstname + " " + character.Name + "</option>";
                    }
                }
                html += "</select><input id=\"uniteCombat-" + combat.IdHouseAttack + "-" + combat.IdHouseDefense + "\" type=\"number\" min=\"0\" max=\"" + listJoueur[index].Maison.nbAttaquant + "\" step=\"1\" value=\"" + listJoueur[index].Maison.nbAttaquant / CombatTS.listCombat.filter(function (fight) { return fight.IdHouseAttack === combat.IdHouseAttack; }).length + "\"/></td>";
                i++;
            }
            if (i % 2 == 0) {
                html += "</tr><tr>";
            }
        };
        for (var _i = 0, _a = CombatTS.listCombat; _i < _a.length; _i++) {
            var combat = _a[_i];
            _loop_1(combat);
        }
        $('#tableCombat').append(html);
        $('select').on('change', function (event) {
            var prevValue = $(this).data('previous');
            $('select').not(this).find('option[value="' + prevValue + '"]').show();
            var value = $(this).val();
            $(this).data('previous', value);
            $('select').not(this).find('option[value="' + value + '"]').hide();
        });
    }
    function defineHandlerPage4() {
        $("#etape4").click(function () {
            var heros = $('select[id^="heroCombat-"]');
            var attaquant = $('input[id^="uniteCombat-"]');
            var i;
            for (i = 0; i < heros.length; i++) {
                var idHero = heros.eq(i).attr("id");
                var idAttaquant = attaquant.eq(i).attr("id");
                var resHero = idHero.split("-");
                var resAttaquant = idAttaquant.split("-");
                CombatTS.listCombat.filter(function (fight) { return fight.IdHouseAttack === parseInt(resHero[1]) && fight.IdHouseDefense === parseInt(resHero[2]); })[0].NbUniteAttack = attaquant.eq(i).val();
                CombatTS.listCombat.filter(function (fight) { return fight.IdHouseAttack === parseInt(resHero[1]) && fight.IdHouseDefense === parseInt(resHero[2]); })[0].IdHeroAttack = heros.eq(i).val();
            }
            index++;
            if (index < listJoueur.length) {
                $('#listJoueur li').css({ "border-bottom": "1px solid red" });
                $('#listJoueur li').eq(index).css({ "border-bottom": "1px solid green" });
                paramAttaque();
            }
            else {
                $('#main').empty();
                $('#main').load("/Home/Page5", function (response, status, xhr) {
                    if (status == "error") {
                        var msg = "Sorry but there was an error: ";
                        $("#error").html(msg + xhr.status + " " + xhr.statusText);
                    }
                    else {
                        index = 0;
                        supprHandler4();
                        paramDefense();
                        defineHandlerPage5();
                        $('#listJoueur li').css({ "border-bottom": "1px solid red" });
                        $('#listJoueur li').first().css({ "border-bottom": "1px solid green" });
                    }
                });
            }
        });
    }
    function supprHandler4() {
        $('select').unbind();
        $("#etape4").unbind();
    }
    function paramDefense() {
        $('#tableCombat').empty();
        var i = 0;
        var html = "";
        html += "<tr>";
        var _loop_2 = function (combat) {
            if (combat.IdHouseDefense == listJoueur[index].Maison.IdHouse) {
                var adversaire = HouseTS.listMaison.filter(function (maison) { return maison.IdHouse === combat.IdHouseAttack; });
                html += "<td><label>Combat contre " + adversaire[0].Name + "</label><select id=\"heroCombat-" + combat.IdHouseDefense + "-" + combat.IdHouseAttack + "\"><option>-</option>";
                for (var _i = 0, _a = listJoueur[index].Maison.listHero; _i < _a.length; _i++) {
                    var character = _a[_i];
                    if (character.Type == Fonction.Defenseur) {
                        html += "<option value=\"" + character.IdCharacter + "\">" + character.Firstname + " " + character.Name + "</option>";
                    }
                }
                html += "</select><input id=\"uniteCombat-" + combat.IdHouseDefense + "-" + combat.IdHouseAttack + "\" type=\"number\" min=\"0\" max=\"" + (listJoueur[index].Maison.nbUnite - listJoueur[index].Maison.nbAttaquant) + "\" step=\"1\" value=\"" + (listJoueur[index].Maison.nbUnite - listJoueur[index].Maison.nbAttaquant) / CombatTS.listCombat.filter(function (fight) { return fight.IdHouseDefense === combat.IdHouseDefense; }).length + "\"/></td>";
                i++;
            }
            if (i % 2 == 0) {
                html += "</tr><tr>";
            }
        };
        for (var _i = 0, _a = CombatTS.listCombat; _i < _a.length; _i++) {
            var combat = _a[_i];
            _loop_2(combat);
        }
        $('#tableCombat').append(html);
        $('select').on('change', function (event) {
            var prevValue = $(this).data('previous');
            $('select').not(this).find('option[value="' + prevValue + '"]').show();
            var value = $(this).val();
            $(this).data('previous', value);
            $('select').not(this).find('option[value="' + value + '"]').hide();
        });
    }
    function defineHandlerPage5() {
        $("#etape5").click(function () {
            var heros = $('select[id^="heroCombat-"]');
            var defenseur = $('input[id^="uniteCombat-"]');
            var i;
            for (i = 0; i < heros.length; i++) {
                var idHero = heros.eq(i).attr("id");
                var idDefenseur = defenseur.eq(i).attr("id");
                var resHero = idHero.split("-");
                var resDefenseur = idDefenseur.split("-");
                CombatTS.listCombat.filter(function (fight) { return fight.IdHouseDefense === parseInt(resHero[1]) && fight.IdHouseAttack === parseInt(resHero[2]); })[0].NbUniteDefense = defenseur.eq(i).val();
                CombatTS.listCombat.filter(function (fight) { return fight.IdHouseDefense === parseInt(resHero[1]) && fight.IdHouseAttack === parseInt(resHero[2]); })[0].IdHeroDefense = heros.eq(i).val();
            }
            index++;
            if (index < listJoueur.length) {
                $('#listJoueur li').css({ "border-bottom": "1px solid red" });
                $('#listJoueur li').eq(index).css({ "border-bottom": "1px solid green" });
                paramDefense();
            }
            else {
                //Affichage resultat
                //MAJ House
                //MAJ Player si house morte
                //flush CombatTS.listCombat
                //execution du code ci dessous
                $('#main').empty();
                $('#main').load("/Home/Page2", function (response, status, xhr) {
                    if (status == "error") {
                        var msg = "Sorry but there was an error: ";
                        $("#error").html(msg + xhr.status + " " + xhr.statusText);
                    }
                    else {
                        supprHandler5();
                        choixAdversaire();
                        defineHandlerPage2();
                        $('#listJoueur li').css({ "border-bottom": "1px solid red" });
                        $('#listJoueur li').first().css({ "border-bottom": "1px solid green" });
                    }
                });
            }
        });
    }
    function supprHandler5() {
        $('select').unbind();
        $("#etape4").unbind();
    }
});
var PlayerTS = /** @class */ (function () {
    function PlayerTS(Name, Maison) {
        this.IdPlayer = PlayerTS.count;
        PlayerTS.count++;
        this.Name = Name;
        this.Maison = Maison;
    }
    PlayerTS.prototype.afficherPlayer = function () {
        var myThis = this;
        var div = $('<div>' + this.Name + '</div>');
        div[0].onclick = function (e) {
            myThis.openInfoCharacter();
        };
        return div;
    };
    PlayerTS.prototype.openInfoCharacter = function () {
        alert('ouvrir info du personnage ' + this.Name);
    };
    PlayerTS.count = 0;
    return PlayerTS;
}());
//# sourceMappingURL=PlayerTS.js.map