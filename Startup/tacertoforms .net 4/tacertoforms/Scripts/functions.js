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


var paises = {
    'Afeganistão': 'Afeganistão',
    'África do Sul': 'África do Sul',
    'Albânia': 'Albânia',
    'Alemanha': 'Alemanha',
    'Andorra': 'Andorra',
    'Angola': 'Angola',
    'Antiga e Barbuda': 'Antiga e Barbuda',
    'Arábia Saudita': 'Arábia Saudita',
    'Argélia': 'Argélia',
    'Argentina': 'Argentina',
    'Arménia': 'Arménia',
    'Austrália': 'Austrália',
    'Áustria': 'Áustria',
    'Azerbaijão': 'Azerbaijão',
    'Bahamas': 'Bahamas',
    'Bangladexe': 'Bangladexe',
    'Barbados': 'Barbados',
    'Barém': 'Barém',
    'Bélgica': 'Bélgica',
    'Belize': 'Belize',
    'Benim': 'Benim',
    'Bielorrússia': 'Bielorrússia',
    'Bolívia': 'Bolívia',
    'Bósnia e Herzegovina': 'Bósnia e Herzegovina',
    'Botsuana': 'Botsuana',
    'Brasil': 'Brasil',
    'Brunei': 'Brunei',
    'Bulgária': 'Bulgária',
    'Burquina Faso': 'Burquina Faso',
    'Burúndi': 'Burúndi',
    'Butão': 'Butão',
    'Cabo Verde': 'Cabo Verde',
    'Camarões': 'Camarões',
    'Camboja': 'Camboja',
    'Canadá': 'Canadá',
    'Catar': 'Catar',
    'Cazaquistão': 'Cazaquistão',
    'Chade': 'Chade',
    'Chile': 'Chile',
    'China': 'China',
    'Chipre': 'Chipre',
    'Colômbia': 'Colômbia',
    'Comores': 'Comores',
    'Congo- Brazzaville': 'Congo- Brazzaville',
    'Coreia do Norte': 'Coreia do Norte',
    'Coreia do Sul': 'Coreia do Sul',
    'Cosovo': 'Cosovo',
    'Costa do Marfim': 'Costa do Marfim',
    'Costa Rica': 'Costa Rica',
    'Croácia': 'Croácia',
    'Cuaite': 'Cuaite',
    'Cuba': 'Cuba',
    'Dinamarca': 'Dinamarca',
    'Dominica': 'Dominica',
    'Egito': 'Egito',
    'Emirados Árabes Unidos': 'Emirados Árabes Unidos',
    'Equador': 'Equador',
    'Eritreia': 'Eritreia',
    'Eslováquia': 'Eslováquia',
    'Eslovénia': 'Eslovénia',
    'Espanha': 'Espanha',
    'Estado da Palestina': 'Estado da Palestina',
    'Estados Unidos': 'Estados Unidos',
    'Estónia': 'Estónia',
    'Etiópia': 'Etiópia',
    'Fiji': 'Fiji',
    'Filipinas': 'Filipinas',
    'Finlândia': 'Finlândia',
    'França': 'França',
    'Gabão': 'Gabão',
    'Gâmbia': 'Gâmbia',
    'Gana': 'Gana',
    'Geórgia': 'Geórgia',
    'Granada': 'Granada',
    'Grécia': 'Grécia',
    'Guatemala': 'Guatemala',
    'Guiana': 'Guiana',
    'Guiné': 'Guiné',
    'Guiné Equatorial': 'Guiné Equatorial',
    'Guiné - Bissau': 'Guiné - Bissau',
    'Haiti': 'Haiti',
    'Honduras': 'Honduras',
    'Hungria': 'Hungria',
    'Iémen': 'Iémen',
    'Ilhas Marechal': 'Ilhas Marechal',
    'Índia': 'Índia',
    'Indonésia': 'Indonésia',
    'Irão': 'Irão',
    'Iraque': 'Iraque',
    'Irlanda': 'Irlanda',
    'Islândia': 'Islândia',
    'Israel': 'Israel',
    'Itália': 'Itália',
    'Jamaica': 'Jamaica',
    'Japão': 'Japão',
    'Jibuti': 'Jibuti',
    'Jordânia': 'Jordânia',
    'Laus': 'Laus',
    'Lesoto': 'Lesoto',
    'Letónia': 'Letónia',
    'Líbano': 'Líbano',
    'Libéria': 'Libéria',
    'Líbia': 'Líbia',
    'Listenstaine': 'Listenstaine',
    'Lituânia': 'Lituânia',
    'Luxemburgo': 'Luxemburgo',
    'Macedónia': 'Macedónia',
    'Madagáscar': 'Madagáscar',
    'Malásia': 'Malásia',
    'Maláui': 'Maláui',
    'Maldivas': 'Maldivas',
    'Mali': 'Mali',
    'Malta': 'Malta',
    'Marrocos': 'Marrocos',
    'Maurícia': 'Maurícia',
    'Mauritânia': 'Mauritânia',
    'México': 'México',
    'Mianmar': 'Mianmar',
    'Micronésia': 'Micronésia',
    'Moçambique': 'Moçambique',
    'Moldávia': 'Moldávia',
    'Mónaco': 'Mónaco',
    'Mongólia': 'Mongólia',
    'Montenegro': 'Montenegro',
    'Namíbia': 'Namíbia',
    'Nauru': 'Nauru',
    'Nepal': 'Nepal',
    'Nicarágua': 'Nicarágua',
    'Níger': 'Níger',
    'Nigéria': 'Nigéria',
    'Noruega': 'Noruega',
    'Nova Zelândia': 'Nova Zelândia',
    'Omã': 'Omã',
    'Países Baixos': 'Países Baixos',
    'Palau': 'Palau',
    'Panamá': 'Panamá',
    'Papua Nova Guiné': 'Papua Nova Guiné',
    'Paquistão': 'Paquistão',
    'Paraguai': 'Paraguai',
    'Peru': 'Peru',
    'Polónia': 'Polónia',
    'Portugal': 'Portugal',
    'Quénia': 'Quénia',
    'Quirguistão': 'Quirguistão',
    'Quiribáti': 'Quiribáti',
    'Reino Unido': 'Reino Unido',
    'República Centro - Africana': 'República Centro - Africana',
    'República Checa': 'República Checa',
    'República Democrática do Congo': 'República Democrática do Congo',
    'República Dominicana': 'República Dominicana',
    'Roménia': 'Roménia',
    'Ruanda': 'Ruanda',
    'Rússia': 'Rússia',
    'Salomão': 'Salomão',
    'Salvador': 'Salvador',
    'Samoa': 'Samoa',
    'Santa Lúcia': 'Santa Lúcia',
    'São Cristóvão e Neves': 'São Cristóvão e Neves',
    'São Marinho': 'São Marinho',
    'São Tomé e Príncipe': 'São Tomé e Príncipe',
    'São Vicente e Granadinas': 'São Vicente e Granadinas',
    'Seicheles': 'Seicheles',
    'Senegal': 'Senegal',
    'Serra Leoa': 'Serra Leoa',
    'Sérvia': 'Sérvia',
    'Singapura': 'Singapura',
    'Síria': 'Síria',
    'Somália': 'Somália',
    'Sri Lanca': 'Sri Lanca',
    'Suazilândia': 'Suazilândia',
    'Sudão': 'Sudão',
    'Sudão do Sul': 'Sudão do Sul',
    'Suécia': 'Suécia',
    'Suíça': 'Suíça',
    'Suriname': 'Suriname',
    'Tailândia': 'Tailândia',
    'Taiuã': 'Taiuã',
    'Tajiquistão': 'Tajiquistão',
    'Tanzânia': 'Tanzânia',
    'Timor - Leste': 'Timor - Leste',
    'Togo': 'Togo',
    'Tonga': 'Tonga',
    'Trindade e Tobago': 'Trindade e Tobago',
    'Tunísia': 'Tunísia',
    'Turcomenistão': 'Turcomenistão',
    'Turquia': 'Turquia',
    'Tuvalu': 'Tuvalu',
    'Ucrânia': 'Ucrânia',
    'Uganda': 'Uganda',
    'Uruguai': 'Uruguai',
    'Usbequistão': 'Usbequistão',
    'Vanuatu': 'Vanuatu',
    'Vaticano': 'Vaticano',
    'Venezuela': 'Venezuela',
    'Vietname': 'Vietname',
    'Zâmbia': 'Zâmbia',
    'Zimbábue': 'Zimbábue'
}