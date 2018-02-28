//$(document).ready(function () {
//    $.ajax({
//        type: "GET",
//        url: "/House/GetAllHouse",
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
function startGame() {
    var listJoueur = new Array();
    var index = 0;
    alert("C’est une bonne situation ça scribe ?\nVous savez, moi je ne crois pas qu’il y ait de bonne ou de mauvaise situation. Moi, si je devais résumer ma vie aujourd’hui avec vous, je dirais que c’est d’abord des rencontres. Des gens qui m’ont tendu la main, peut-être à un moment où je ne pouvais pas, où j’étais seul chez moi. Et c’est assez curieux de se dire que les hasards, les rencontres forgent une destinée... Parce que quand on a le goût de la chose, quand on a le goût de la chose bien faite, le beau geste, parfois on ne trouve pas l’interlocuteur en face je dirais, le miroir qui vous aide à avancer. Alors ça n’est pas mon cas, comme je disais là, puisque moi au contraire, j’ai pu : et je dis merci à la vie, je lui dis merci, je chante la vie, je danse la vie... je ne suis qu’amour ! Et finalement, quand beaucoup de gens aujourd’hui me disent « Mais comment fais-tu pour avoir cette humanité ? », et bien je leur réponds très simplement, je leur dis que c’est ce goût de l’amour ce goût donc qui m’a poussé aujourd’hui à entreprendre une construction mécanique, mais demain qui sait ? Peut-être simplement à me mettre au service de la communauté, à faire le don, le don de soi...");
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
        supprHandler1();
        $('#main').empty();
        $('#main').load("/Home/Page2", function (response, status, xhr) {
            if (status == "error") {
                var msg = "Sorry but there was an error: ";
                $("#error").html(msg + xhr.status + " " + xhr.statusText);
            }
            else {
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
            $('#hero table').append("<tr><td>" + character.Prenom + " " + character.Nom + "</td><td><input class=\"character combat\" id=\"checkBox" + indexTab + "-1\" value=\"" + indexTab + "-1\" type= \"checkbox\" > </td><td> <input class=\"character combat\" id=\"checkBox" + indexTab + "-2\" value=\"" + indexTab + "-2\" type= \"checkbox\" > </td><td> <input class=\"character combat\" id=\"checkBox" + indexTab + "-3\" value=\"" + indexTab + "-3\" type= \"checkbox\" > </td></tr>");
            indexTab++;
        }
        var checkBoxes = $('input.combat');
        checkBoxes.on("customChange", function () {
            var checkBoxesEnnemie = $('input.ennemie:checked').length;
            var checkBoxesCharacter = $('input.character:checked').length;
            var nbAttaquant = $('input.character[value$="-2"]:checked').length;
            var nbDefenseur = $('input.character[value$="-3"]:checked').length;
            if (checkBoxesEnnemie >= 1 && checkBoxesEnnemie <= nbAttaquant && nbDefenseur >= 1 && checkBoxesCharacter == listJoueur[index].Maison.listHero.length) {
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
            var nbDefenseur = $('input.character[value$="-3"]:checked').length;
            if (checkBoxesEnnemie >= 1 && checkBoxesEnnemie <= nbAttaquant && nbDefenseur >= 1 && checkBoxesCharacter == listJoueur[index].Maison.listHero.length) {
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
                supprHandler2();
                $('#main').empty();
                $('#main').load("/Home/Page3", function (response, status, xhr) {
                    if (status == "error") {
                        var msg = "Sorry but there was an error: ";
                        $("#error").html(msg + xhr.status + " " + xhr.statusText);
                    }
                    else {
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
        $('#main').on("change", ":input", function () {
            var cb = $(this);
            var id = cb.attr("id");
            if (id == "attaque") {
                $('#defense').val(listJoueur[index].Maison.nbUnite - $('#attaque').val());
            }
            if (id == "defense") {
                $('#attaque').val(listJoueur[index].Maison.nbUnite - $('#defense').val());
            }
        });
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
                supprHandler3();
                $('#main').empty();
                $('#main').load("/Home/Page4", function (response, status, xhr) {
                    if (status == "error") {
                        var msg = "Sorry but there was an error: ";
                        $("#error").html(msg + xhr.status + " " + xhr.statusText);
                    }
                    else {
                        index = 0;
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
        $('#main').unbind();
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
                        html += "<option value=\"" + character.IdCharacter + "\">" + character.Prenom + " " + character.Nom + "</option>";
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
        $('input[id^=uniteCombat-]').on('change', function (event) {
            var spinnerLenght = $('input[id^=uniteCombat-]').length;
            var total = 0;
            for (var compteur = 0; compteur < spinnerLenght; compteur++) {
                total += parseInt($('input[id^=uniteCombat-]').eq(compteur).val());
            }
            if (total <= listJoueur[index].Maison.nbAttaquant) {
                $('#etape4').prop("disabled", false);
            }
            else {
                $('#etape4').prop("disabled", true);
            }
        });
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
                supprHandler4();
                $('#main').empty();
                $('#main').load("/Home/Page5", function (response, status, xhr) {
                    if (status == "error") {
                        var msg = "Sorry but there was an error: ";
                        $("#error").html(msg + xhr.status + " " + xhr.statusText);
                    }
                    else {
                        index = 0;
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
                //html += "<td><label>Combat contre " + adversaire[0].Name + "</label><select id=\"heroCombat-" + combat.IdHouseDefense + "-" + combat.IdHouseAttack + "\"><option>-</option>";
                html += "<td><label>Combat contre " + adversaire[0].Name;
                //for (let character of listJoueur[index].Maison.listHero) {
                //    if (character.Type == Fonction.Defenseur) {
                //        html += "<option value=\"" + character.IdCharacter + "\">" + character.Prenom + " " + character.Name + "</option>";
                //    }
                //}
                //html += "</select><input id=\"uniteCombat-" + combat.IdHouseDefense + "-" + combat.IdHouseAttack + "\" type=\"number\" min=\"0\" max=\"" + (listJoueur[index].Maison.nbUnite - listJoueur[index].Maison.nbAttaquant) + "\" step=\"1\" value=\"" + (listJoueur[index].Maison.nbUnite - listJoueur[index].Maison.nbAttaquant) / CombatTS.listCombat.filter(fight => fight.IdHouseDefense === combat.IdHouseDefense).length + "\"/></td>";
                html += "<input id=\"uniteCombat-" + combat.IdHouseDefense + "-" + combat.IdHouseAttack + "\" type=\"number\" min=\"0\" max=\"" + (listJoueur[index].Maison.nbUnite - listJoueur[index].Maison.nbAttaquant) + "\" step=\"1\" value=\"" + (listJoueur[index].Maison.nbUnite - listJoueur[index].Maison.nbAttaquant) / CombatTS.listCombat.filter(function (fight) { return fight.IdHouseDefense === combat.IdHouseDefense; }).length + "\"/></td>";
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
        $('input[id^=uniteCombat-]').on('change', function (event) {
            var spinnerLenght = $('input[id^=uniteCombat-]').length;
            var total = 0;
            for (var compteur = 0; compteur < spinnerLenght; compteur++) {
                total += parseInt($('input[id^=uniteCombat-]').eq(compteur).val());
            }
            if (total <= listJoueur[index].Maison.nbAttaquant) {
                $('#etape4').prop("disabled", false);
            }
            else {
                $('#etape4').prop("disabled", true);
            }
        });
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
            //var heros = $('select[id^="heroCombat-"]');
            var defenseur = $('input[id^="uniteCombat-"]');
            var i;
            for (i = 0; i < defenseur.length; i++) {
                //var idHero = heros.eq(i).attr("id");
                var idDefenseur = defenseur.eq(i).attr("id");
                //var resHero = idHero.split("-");
                var resDefenseur = idDefenseur.split("-");
                CombatTS.listCombat.filter(function (fight) { return fight.IdHouseDefense === parseInt(resDefenseur[1]) && fight.IdHouseAttack === parseInt(resDefenseur[2]); })[0].NbUniteDefense = defenseur.eq(i).val();
                for (var _i = 0, _a = listJoueur[index].Maison.listHero.filter(function (heroDefense) { return heroDefense.Type == Fonction.Defenseur; }); _i < _a.length; _i++) {
                    var heroDefenseur = _a[_i];
                    CombatTS.listCombat.filter(function (fight) { return fight.IdHouseDefense === parseInt(resDefenseur[1]) && fight.IdHouseAttack === parseInt(resDefenseur[2]); })[0].ListIdHeroDefense.push(heroDefenseur.IdCharacter);
                }
                for (var _b = 0, _c = listJoueur[index].Maison.listHero.filter(function (heroSoin) { return heroSoin.Type == Fonction.Soin; }); _b < _c.length; _b++) {
                    var heroSoins = _c[_b];
                    CombatTS.listCombat.filter(function (fight) { return fight.IdHouseDefense === parseInt(resDefenseur[1]) && fight.IdHouseAttack === parseInt(resDefenseur[2]); })[0].ListHeroSoins.push(heroSoins.IdCharacter);
                }
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
                var jsonString = JSON.stringify(CombatTS.listCombat);
                $.ajax({
                    type: "POST",
                    url: "/Combat/SendFight",
                    data: jsonString,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    //GET RESULT
                    success: function (success) {
                        //let list: CombatTS[] = success as CombatTS[];
                        //$.each(success, function (index, element) {
                        //    let character: CombatTS = new CombatTS(element.IdHouseAttack, element.IdHouseDefense, element.NbUniteAttack, element.NbUniteDefense);
                        //    list.push(character);
                        //});
                        //list.forEach(function (element: CombatTS) {
                        //    $('#div_list_character_ts').append(element.afficherCombat);
                        //});
                        if (success == "Success") {
                            tourSuivant();
                        }
                    },
                    error: function (error) {
                        alert(error);
                    }
                });
            }
        });
    }
    function tourSuivant() {
        $.ajax({
            type: "GET",
            url: "/House/GetHouses",
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (success) {
                var list = success;
                $.each(JSON.parse(success), function (index, element) {
                    var listCharacter = element.ListCharacters;
                    //$.each(element.ListCharacters, function (index2, element2) {
                    //    let character: CharacterTS = new CharacterTS(element2.IdCharacter, element2.Nom, element2.Prenom, null);
                    //    listCharacter.push(character);
                    //});
                    var house = new HouseTS(element.IdHouse, element.NomHouse, element.NbUnities, listCharacter);
                    HouseTS.listMaison.push(house);
                });
            },
            complete: function (data) {
                supprHandler5();
                $('#main').empty();
                $('#main').load("/Home/Page2", function (response, status, xhr) {
                    if (status == "error") {
                        var msg = "Sorry but there was an error: ";
                        $("#error").html(msg + xhr.status + " " + xhr.statusText);
                    }
                    else {
                        reset();
                        index = 0;
                        choixAdversaire();
                        defineHandlerPage2();
                        $('#listJoueur li').css({ "border-bottom": "1px solid red" });
                        $('#listJoueur li').first().css({ "border-bottom": "1px solid green" });
                    }
                });
            },
            error: function (error) {
                alert(error);
            }
        });
    }
    function reset() {
        while (CombatTS.listCombat.length > 0) {
            CombatTS.listCombat.pop();
        }
        $("#listJoueur").empty();
        var _loop_3 = function (joueur) {
            if (HouseTS.listMaison.filter(function (house) { return house.IdHouse == joueur.Maison.IdHouse; }).length == 0) {
                listJoueur.slice(listJoueur.indexOf(joueur));
            }
            else {
                $("#listJoueur").append("<li value=\"" + joueur.Maison.IdHouse + "\">" + joueur.Name + " - <strong>" + joueur.Maison.Name + "</strong></li>");
            }
        };
        for (var _i = 0, listJoueur_2 = listJoueur; _i < listJoueur_2.length; _i++) {
            var joueur = listJoueur_2[_i];
            _loop_3(joueur);
        }
    }
    function supprHandler5() {
        $('select').unbind();
        $("#etape5").unbind();
    }
}
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