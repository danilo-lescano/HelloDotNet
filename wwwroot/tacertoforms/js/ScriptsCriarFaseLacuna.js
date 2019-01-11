var ScriptsCriarFaseLacuna = {
    listaDeDesafios: [],
    quantidadeQuestoes: 0,
    idQuestaoAtual: 0,
    editando: -1,
    desafio: function(index, id, faseId, significado, dica){
        if(index !== null)
            this.index = index;
        this.id = id;
        this.faseId = faseId;
        this.significado = significado;
        this.dica = dica;
        this.resposta = [{
            conteudo: "",
            posicao: 0
        }]
        this.fraseXLacuna = [{
            eFrase: "",
            conteudo: ""
        }]  
    },
    lastPalavra: "",
    lacunasMaximas: 0,
    lacunasAtuais: 0,
    idAtual: 0,
    lacunaText: "",
    newLacuna: "", 
    numeroDeLacunasAtual: 0,
    significadoTextEdit: "",
    dicaTextEdit: "",
    lacunasContainer: "",
    iframe: null,
    iframeFraseContainer: null,
    iframeFraseText: "",
    iframeLacunasContainer: null,
    elemento: null, // Elemento que está sendo editado
    botaoAdd: null, // Elemento do botão de Adicionar palavra
    botaoEdit: null, // Elemento do botão de Editar palavra
    botaoSave: null, // Elemento do botão de Salvar fase
    botaoDeletar: null, // Elemento do botão de Deletar palavra
    loadData: function(){
        console.log("sdfsdfsdfs");
        this.lacunaText = document.getElementById('lacunaText');
        this.lacunaText.innerHTML = "";
        this.lacunaSecondText = document.getElementById('lacunaSecondText');
        this.newLacuna = document.getElementById('newLacunaText');
        this.significadoTextEdit = document.getElementById('textoSignificado');
        this.dicaTextEdit = document.getElementById('textoDica');
        this.lacunasContainer = document.getElementById('lacunasAdicionadas');

        this.botaoAdd = document.getElementById('botaoAdd');
        this.botaoEdit = document.getElementById('botaoEdit');
        this.botaoSave = document.getElementById('botaoSave');
        this.botaoDeletar = document.getElementById('botaoApagar');
        
        this.iframe = document.getElementById('lacunaIframe');
        innerDoc = (this.iframe.contentDocument) ? this.iframe.contentDocument : this.iframe.contentWindow.document;
        this.iframeFraseContainer = innerDoc.getElementById('lacConteudoWrapper');        
        this.iframeLacunasContainer = innerDoc.getElementById('lacunaResp');
        this.lacunaText.focus();  
        
    },
    addLacunaErrada: function(){

        let lacuna = this.checaLacuna();

        if(lacuna != 0){

            //if(this.palavraNaoExiste(lacuna) || this.editando >= 0){

                if(this.editando == -1){ // Não está editando
                    //let lacunasContainer = this.lacunasContainer;
                    this.addNovaLacuna(1, lacuna);
                    
                    //this.listaDeDesafios[this.quantidade++] = new this.desafio(this.quantidade -1, this.quantidade-1, lacuna, this.correto, -1, significado, dica);

                    //document.getElementById('numeroDePalavras').innerHTML = this.quantidade;

                    this.mostraToast(2); // Palavra adicionada
                }else{ // Está editando
                    // var elemento = document.getElementById(this.editando); // Elemento que estou editando
                    if(this.listaDeDesafios[this.editando].palavra != lacuna){
                        this.elemento.childNodes[0].innerHTML = lacuna;
                        this.listaDeDesafios[this.editando].palavra = lacuna; 
                    }
                    if(this.listaDeDesafios[this.editando].eCorreto == true){
                        if(this.correto == false){
                            this.elemento.classList.remove("green");
                            this.elemento.classList.add("red");
                            this.listaDeDesafios[this.editando].eCorreto = this.correto;
                        }
                    }else{
                        if(this.correto == true){
                            this.elemento.classList.remove("red");
                            this.elemento.classList.add("green");
                            this.listaDeDesafios[this.editando].eCorreto = this.correto;
                        }
                    }
                        
                    this.listaDeDesafios[this.editando].significado = significado;
                    this.listaDeDesafios[this.editando].dica = dica;

                    this.estaEditando(0);
                    this.mostraToast(3); // Palavra editada   
                }

                this.limpaElementos(0);
            }else{
                this.mostraToast(4);    
            }
        //}else{
          //  console.log("Chama o toast para o usuario lembrar que tem que escrever uma palavra");
         ////   this.mostraToast(1); // Usuário não escreveu uma palavra
        //}

        this.newLacuna.focus();
        //this.mostraBotaoSalvar();
    },
    textoLacunaClicado(){
        // <div class="padThis"><div class="draggableLacuna lacunaAlternativa ui-draggable" style="position: relative;">mais</div></div>
        let selObj = window.getSelection(); 

        let selectedText = selObj.toString();
        console.log(selectedText);
        if(selectedText != " " && selectedText != ""){
            if(this.numeroDeLacunasAtual < 6){
                this.addNovaLacuna(0, selectedText);
                
                //this.listaDeDesafios[this.quantidade++] = new this.desafio(this.quantidade -1, this.quantidade-1, palavra, this.correto, -1, significado, dica);

                //document.getElementById('numeroDePalavras').innerHTML = this.quantidade;
                ++this.numeroDeLacunasAtual;
                
            }else{
                console.log("o numero maximo de lacunas é 6");
            }
        }

        // tenho que checar a posição que a lacuna foi criada
        // Tenho que adicionar a lacuna embaixo
    
    },
    addNovaLacuna(op, text){
        if(op === 0){
            this.iframeLacunasContainer.innerHTML += "<div class='padThis'><div class='draggableLacuna lacunaAlternativa ui-draggable' style='position: relative;'>"+text+"</div></div>";
                
            this.lacunasContainer.innerHTML += '<div id = "' + this.numeroDeLacunasAtual+'" class="palavraBox green" onclick="ScriptsCriarFaseLacuna.carregaParaEditar(this.id)"><h6>'+text+'</h6></div>';
                    
        }else if(op == 1){

            this.iframeLacunasContainer.innerHTML += "<div class='padThis'><div class='draggableLacuna lacunaAlternativa ui-draggable' style='position: relative;'>"+text+"</div></div>";

            this.lacunasContainer.innerHTML += '<div id = "' + this.quantidade+'" class="palavraBox red" onclick="ScriptsCriarLacuna.showApagar(this.id)"><h6>'+text+'</h6></div>';
        }
    },
    addDesafio(){
        if(this.desafio[this.idAtual].lacuna.length > 1){
            Console.log("Add desafio na fase");            
        }else{
            Console.log("Avisar que cada desafio precisa ter no minimo duas lacunas");
        }
    },
    checaLacuna: function(){
        let lacuna = this.newLacuna.value;
        
        if(lacuna != false)
            return lacuna;
        lacuna = 0;
        return lacuna;
    },
    mostraToast: function(op){
        
        if(op == 1){ // Pessoa não digitou uma palavra
            //Materialize.toast('I am a toast!', 3000, 'blue rounded');
            M.toast({html: 'Você precisa digitar uma palavra!', classes: 'rounded red lighten-1 palavraFaltandoModoNormal'});
        }else if(op == 2){ // Palavra foi adicionada
            M.toast({html: 'Palavra adicionada!', classes: 'rounded green lighten-1'});
        }else if(op == 3){ // Palavra foi modificada
            M.toast({html: 'Palavra modificada!', classes: 'rounded lime'});
        }else if(op == 4){ // Palavra já foi adicionada
            M.toast({html: 'Palavra já foi adicionada!', classes: 'rounded red lighten-1'});
        }else if(op == 5){ // Palavra foi removida
            M.toast({html: 'Palavra foi removida!', classes: 'rounded red lighten-1'});
        }
    },
    pegaCor: function(){
        let cor = "green";
        if(this.radioResposta[0].checked){
            this.correto = true;
        }else if(this.radioResposta[1].checked){
            cor = "red";
            this.correto = false;
            this.radioResposta[0].checked = true;
        }    

        return cor;
    },
    carregaParaEditar: function(id_clicado){
        if(this.editando >= 0){ // Já tem alguém editando logo devo mudar
            this.elemento.classList.remove("editandoPalavraModoNormal");         
        }

        this.editando = parseInt(id_clicado);
            
        elementos = this.listaDeDesafios[this.editando];

        this.elemento = document.getElementById(this.editando); // Elemento que estou editando

        this.elemento.classList.add("editandoPalavraModoNormal");

        document.getElementById('palavraText').value = elementos.palavra;
        if(elementos.eCorreto == true)
            this.radioResposta[0].checked = true;
        else
            this.radioResposta[1].checked = true;

        if(elementos.significado == undefined)
            this.significadoTextEdit.value = "";
        else
            this.significadoTextEdit.value = elementos.significado;

        if(elementos.dica == undefined)
            this.dicaTextEdit.value = "";
        else
            this.dicaTextEdit.value = elementos.dica;

        this.estaEditando(1); 
    },
    trocaFraseLacuna: function(frase){
        
        let lastChar = frase[frase.length-1];
        let novaFrase = "";
        console.log(lastChar);
        if(lastChar == " "){ // Foi digitado um espaço
            if(this.lastPalavra.length == 0){ //Próximos char tem que entrar na palavra
                novaFrase = " ";
                this.lastPalavra = " ";
            }else{ //Palavra nova, colocar span nela
                novaFrase = "<span>"+this.lastPalavra+"</span> ";
                this.lastPalavra = "";
            }
        }else{
            this.lastPalavra += lastChar;
            novaFrase += this.lastPalavra;
        }

        this.iframeFraseText = novaFrase;

        //"<div class='padThis'><div id='lacuna1' class='emptyLacuna droppableLacuna ui-draggable'></div></div>"
        this.iframeFraseContainer.innerHTML = this.iframeFraseText;
    },
    // Checa se a palavra escrita na lacuna já não está em outra lacuna
    palavraNaoExiste: function(palavra){
        let naoexiste = true;

        for(let i = 0; i < this.desafio.lacuna.length && naoexiste; i++){
            if(palavra.toLowerCase() == this.desafio[idAtual].lacuna[i].palavra.toLowerCase())
                naoexiste = false;
        }

        return naoexiste;
    },
    mostraBotaoSalvar: function(){

        if(this.quantidade == 0){
            this.botaoSave.classList.add("ghostElement");
        }else if(this.quantidade == 1){
            this.botaoSave.classList.remove("ghostElement");
        }
    },
    apagarPalavra: function(){
        let indexParaApagar = this.editando;
        console.log(this.listaDeDesafios);

        this.elemento.parentNode.removeChild(this.elemento);

        console.log("dEVOO APAGAR: " + indexParaApagar + "   olha a quantidade atual = "+ this.quantidade);
        if(this.editando >= 0 && this.editando < this.quantidade-1){
            console.log("apagar alguem sem ser o ultimo");
            for(var i = this.editando; i < this.quantidade-1; ++i){
                console.log(this.listaDeDesafios);
                var aux = this.listaDeDesafios[i+1];
                console.log((i+1)+ "    "+aux + "       " + this.listaDeDesafios[i+1]);
                this.listaDeDesafios[i] =  new this.desafio(aux.index-1, aux.id-1, aux.palavra, aux.eCorreto, aux.faseId, aux.significado, aux.dica);
                document.getElementById(i+1).id = i;
            }
        }

        this.quantidade -= 1;
        this.listaDeDesafios.length = this.quantidade;
        this.editando = -1;

        console.log(this.listaDeDesafios);

        this.limpaElementos();
        this.estaEditando(0);
        this.mostraToast(5);
    },
    estaEditando: function(op){ 
        if(op > 0){ // Está 
            // Dá display num botão e tira o display do outro
            this.botaoAdd.classList.add("ghostElement");
            this.botaoEdit.classList.remove("ghostElement");
            this.botaoDeletar.classList.remove("ghostElement");
            this.botaoSave.classList.add("ghostElement");

        }else if(op == 0){ // Não está  
            this.editando = -1; 
            this.botaoAdd.classList.remove("ghostElement"); 
            this.botaoEdit.classList.add("ghostElement"); 
            this.botaoDeletar.classList.add("ghostElement"); 
            this.botaoSave.classList.remove("ghostElement"); 
            this.elemento.classList.remove("editandoPalavraModoNormal");
        } 

        this.palavraTextEdit.focus(); 

    },
    limpaElementos: function(op){
        if(op === 0){ // Limpa só o campo "Lacunas erradas"
            this.newLacuna.value = "";
        }else if(op === 1){ // Limpa todos os campos e até a lista de Lacunas adicionadas
            this.lacunaText.value = "";
            this.lacunasContainer.innerHTML = null;
            this.significadoTextEdit.value = "";
            this.dicaTextEdit.value = "";
        }        
    },
    serialize: function(obj, prefix){
        var str = [],p;
        for (p in obj) {
            if (obj.hasOwnProperty(p)) {
            var k = prefix ? prefix + "[" + p + "]" : p,
                v = obj[p];
            str.push((v !== null && typeof v === "object") ?
                this.serialize(v, k) :
                encodeURIComponent(k) + "=" + encodeURIComponent(v));
            }
        }
        return str.join("&");
    },
    salvarFase: function(){
        console.log("Devo chamar o controller apropriada para salvar a fase da pessoa");

        var url = "/CriarFase/SalvarFaseLacuna";
            
        var fase = this.generateFase();
            
        var json = JSON.stringify(fase);
        console.log(json);
        
        var xhr = new XMLHttpRequest();
        xhr.open("POST", url, true);
        //xhr.setRequestHeader('Content-type','application/x-www-form-urlencoded');
        xhr.setRequestHeader('Content-type','application/json');
        xhr.onload = function () {
            if (xhr.readyState == 4 && xhr.status == "201") {
                console.log(xhr.responseText);
            } else {
                console.error(xhr.responseText);
            }
        }
        xhr.send(json);

        //window.location.href = '/TaCertoForms/MinhasFases';
    },
    generateFase: function(){
        var fase = {
            id: null,
            usuarioId: null,
            chave: null,
            idTipoFase: null,
            descricao: null,
            desafiosLacuna: [],
            respostaNum: [],
            resposta: [],
            fraseXlacunaNum: [],
            fraseXlacuna: []
        };
        if(FASE !== null){
            fase.id = FASE.id;
            fase.usuarioId = FASE.usuarioId;
            fase.chave = FASE.chave;
            fase.idTipoFase = FASE.idTipoFase;
            fase.descricao = FASE.descricao;
        }
        else{
            fase.usuarioId = USER.id;
        }

        var listaDeDesafiosParaEnviar = [];
        for(var i = 0; i < this.listaDeDesafios.length;i++){
            fase.desafiosLacuna[fase.desafiosLacuna.length] = {
                significado: this.listaDeDesafios[i].significado,
                dica: this.listaDeDesafios[i].dica
            }
        }

        /*\/\/ deletar isso é pra teste \/\/*/
        fase.resposta = [
            {conteudo: "4", position: 1},
            {conteudo: "10", position: 3},
            {conteudo: "100", position: 5},
            {conteudo: "17", position: -1},
            {conteudo: "54", position: -1},
        ];
        fase.fraseXlacuna = [
            /*0*/{frase: true, conteudo: "2+2 = "},
            /*1*/{frase: false},
            /*2*/{frase: true, conteudo: "2*5 = "},
            /*3*/{frase: false},
            /*4*/{frase: true, conteudo: "10*10 = "},
            /*5*/{frase: false},
        ];
        /*/\/\ deletar isso é pra teste /\/\*/
    },
    focusOnMe: function(el, flag){
        console.log(el.innerHTML + "  " +flag)
        if(flag){
            el.classList.add("cloneActive");
        }else if(el.innerHTML == ""){
            el.classList.remove("cloneActive");
        }
    }
}

window.onload = ()=>{
    ScriptsCriarFaseLacuna.loadData();
};

