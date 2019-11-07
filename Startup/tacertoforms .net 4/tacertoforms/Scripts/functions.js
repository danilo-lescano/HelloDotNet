var dados_translate = {
    "sEmptyTable": "Nenhum registro encontrado",
    "sInfo": "Mostrando de _START_ ate _END_ de _TOTAL_ registros",
    "sInfoEmpty": "Mostrando 0 ate 0 de 0 registros",
    "sInfoFiltered": "(Filtrados de _MAX_ registros)",
    "sInfoPostFix": "",
    "sInfoThousands": ".",
    "sLengthMenu": "Mostrar _MENU_ resultados por pagina",
    "sLoadingRecords": "Carregando...",
    "sProcessing": "Processando...",
    "sZeroRecords": "Nenhum registro encontrado",
    "sSearch": "Pesquisar",
    "oPaginate": {
        "sNext": "Proximo",
        "sPrevious": "Anterior",
        "sFirst": "Primeiro",
        "sLast": "Ultimo"
    },
    "oAria": {
        "sSortAscending": ": Ordenar colunas de forma ascendente",
        "sSortDescending": ": Ordenar colunas de forma descendente"
    }
};

var locale_drp = {
    "format": "DD/MM/YYYY",
    "separator": " - ",
    "applyLabel": "Confirmar",
    "cancelLabel": "Cancelar",
    "fromLabel": "de",
    "toLabel": "até",
    "customRangeLabel": "Personalizado",
    "daysOfWeek": [
        "Dom",
        "Seg",
        "Ter",
        "Qua",
        "Qui",
        "Sex",
        "Sáb"
    ],
    "monthNames": [
        "Janeiro",
        "Fevereiro",
        "Março",
        "Abril",
        "Maio",
        "Junho",
        "Julho",
        "Augosto",
        "Setembro",
        "Outubro",
        "Novembro",
        "Dezembro"
    ],
    "firstDay": 1
};

function midiaCreateSingleImage(el, data, width = "100%") {            
    el.html(
        '<img src="/Content/images/upload/' + data.Tabela + '/' + data.IdMidia + data.Extensao +'" width="'+ width +'">' +
        '<a href="javascript:void(0)" id="' + data.IdMidia +'" class="btn btn-danger btn-xs btn-single-remove"><i class="fa fa-remove"></i></a>'+
    '');
}

function validar_cnpj(cnpj) {

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') return false;

    if (cnpj.length != 14)
        return false;


    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999")
        return false;


    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0)) return false;
    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1))
        return false;

    return true;
}


var paises = [
    'Afeganistão',
    'África do Sul',
    'Albânia',
    'Alemanha',
    'Andorra',
    'Angola',
    'Antiga e Barbuda',
    'Arábia Saudita',
    'Argélia',
    'Argentina',
    'Arménia',
    'Austrália',
    'Áustria',
    'Azerbaijão',
    'Bahamas',
    'Bangladexe',
    'Barbados',
    'Barém',
    'Bélgica',
    'Belize',
    'Benim',
    'Bielorrússia',
    'Bolívia',
    'Bósnia e Herzegovina',
    'Botsuana',
    'Brasil',
    'Brunei',
    'Bulgária',
    'Burquina Faso',
    'Burúndi',
    'Butão',
    'Cabo Verde',
    'Camarões',
    'Camboja',
    'Canadá',
    'Catar',
    'Cazaquistão',
    'Chade',
    'Chile',
    'China',
    'Chipre',
    'Colômbia',
    'Comores',
    'Congo- Brazzaville',
    'Coreia do Norte',
    'Coreia do Sul',
    'Cosovo',
    'Costa do Marfim',
    'Costa Rica',
    'Croácia',
    'Cuaite',
    'Cuba',
    'Dinamarca',
    'Dominica',
    'Egito',
    'Emirados Árabes Unidos',
    'Equador',
    'Eritreia',
    'Eslováquia',
    'Eslovénia',
    'Espanha',
    'Estado da Palestina',
    'Estados Unidos',
    'Estónia',
    'Etiópia',
    'Fiji',
    'Filipinas',
    'Finlândia',
    'França',
    'Gabão',
    'Gâmbia',
    'Gana',
    'Geórgia',
    'Granada',
    'Grécia',
    'Guatemala',
    'Guiana',
    'Guiné',
    'Guiné Equatorial',
    'Guiné - Bissau',
    'Haiti',
    'Honduras',
    'Hungria',
    'Iémen',
    'Ilhas Marechal',
    'Índia',
    'Indonésia',
    'Irão',
    'Iraque',
    'Irlanda',
    'Islândia',
    'Israel',
    'Itália',
    'Jamaica',
    'Japão',
    'Jibuti',
    'Jordânia',
    'Laus',
    'Lesoto',
    'Letónia',
    'Líbano',
    'Libéria',
    'Líbia',
    'Listenstaine',
    'Lituânia',
    'Luxemburgo',
    'Macedónia',
    'Madagáscar',
    'Malásia',
    'Maláui',
    'Maldivas',
    'Mali',
    'Malta',
    'Marrocos',
    'Maurícia',
    'Mauritânia',
    'México',
    'Mianmar',
    'Micronésia',
    'Moçambique',
    'Moldávia',
    'Mónaco',
    'Mongólia',
    'Montenegro',
    'Namíbia',
    'Nauru',
    'Nepal',
    'Nicarágua',
    'Níger',
    'Nigéria',
    'Noruega',
    'Nova Zelândia',
    'Omã',
    'Países Baixos',
    'Palau',
    'Panamá',
    'Papua Nova Guiné',
    'Paquistão',
    'Paraguai',
    'Peru',
    'Polónia',
    'Portugal',
    'Quénia',
    'Quirguistão',
    'Quiribáti',
    'Reino Unido',
    'República Centro - Africana',
    'República Checa',
    'República Democrática do Congo',
    'República Dominicana',
    'Roménia',
    'Ruanda',
    'Rússia',
    'Salomão',
    'Salvador',
    'Samoa',
    'Santa Lúcia',
    'São Cristóvão e Neves',
    'São Marinho',
    'São Tomé e Príncipe',
    'São Vicente e Granadinas',
    'Seicheles',
    'Senegal',
    'Serra Leoa',
    'Sérvia',
    'Singapura',
    'Síria',
    'Somália',
    'Sri Lanca',
    'Suazilândia',
    'Sudão',
    'Sudão do Sul',
    'Suécia',
    'Suíça',
    'Suriname',
    'Tailândia',
    'Taiuã',
    'Tajiquistão',
    'Tanzânia',
    'Timor - Leste',
    'Togo',
    'Tonga',
    'Trindade e Tobago',
    'Tunísia',
    'Turcomenistão',
    'Turquia',
    'Tuvalu',
    'Ucrânia',
    'Uganda',
    'Uruguai',
    'Usbequistão',
    'Vanuatu',
    'Vaticano',
    'Venezuela',
    'Vietname',
    'Zâmbia',
    'Zimbábue'
];



function calc_digitos_posicoes(digitos, posicoes = 10, soma_digitos = 0) {
    digitos = digitos.toString();
    for (var i = 0; i < digitos.length; i++) {
        soma_digitos = soma_digitos + (digitos[i] * posicoes);
        posicoes--;
        if (posicoes < 2) {
            posicoes = 9;
        }
    }
    soma_digitos = soma_digitos % 11;
    if (soma_digitos < 2) {
        soma_digitos = 0;
    } else {
        soma_digitos = 11 - soma_digitos;
    }
    var cpf = digitos + soma_digitos;
    return cpf;
}

function valida_cpf(valor) {
    valor = valor.toString();
    valor = valor.replace(/[^0-9]/g, '');
    var digitos = valor.substr(0, 9);
    var novo_cpf = calc_digitos_posicoes(digitos);
    var novo_cpf = calc_digitos_posicoes(novo_cpf, 11);
    if (novo_cpf === valor) {
        return true;
    } else {
        return false;
    }
}

function mensagensValidacao(success, el, mensagemAlert = null) {
    if (success) {
        el.removeClass('has-error');
        el.find('.help-block').hide();
    } else {
        el.addClass('has-error');
        el.find('.help-block').show();
        if (mensagemAlert != null) alert(mensagemAlert);
    }
}