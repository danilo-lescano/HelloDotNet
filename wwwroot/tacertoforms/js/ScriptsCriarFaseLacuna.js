var ScriptsCriarFaseLacuna = {
    listaDeDesafios: [],
    quantidade: 0,
    editando: -1,
    desafio: function(index, id, f1, f2, p, eCorreto, faseId, significado, dica){
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
    idAtual: 0,
    lacunaText: "",
    newLacunaText: "", 
    numeroDeLacunasAtual: 0,
    significadoTextEdit: "",
    dicaTextEdit: "",
    lacunasContainer: "",
    iframe: null,
    innerDoc: null,
    iframeFraseContainer: null,
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
        this.newLacunaText = document.getElementsByName('newLacunaText');
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

        let resp = this.checaLacuna();

        if(lacuna != 0){

            if(this.palavraNaoExiste(lacuna) || this.editando >= 0){
                let cor = this.pegaCor(); // Pega a cor caso a palavra esteja certa ou errada
                sdasdfsadfdsfa
                if(this.editando == -1){ // Não está editando
                    let lacunasContainer = this.lacunasContainer;
                    lacunasContainer.innerHTML += '<div id = "' + this.quantidade+'" class="palavraBox '+cor+'" onclick="ScriptsCriarFaseNormal.carregaParaEditar(this.id)"><h6>'+lacuna+'</h6></div>';
                    
                    this.listaDeDesafios[this.quantidade++] = new this.desafio(this.quantidade -1, this.quantidade-1, lacuna, this.correto, -1, significado, dica);

                    document.getElementById('numeroDePalavras').innerHTML = this.quantidade;

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

                this.limpaElementos();
            }else{
                this.mostraToast(4);    
            }
        }else{
            console.log("Chama o toast para o usuario lembrar que tem que escrever uma palavra");
            this.mostraToast(1); // Usuário não escreveu uma palavra
        }

        this.palavraTextEdit.focus();
        this.mostraBotaoSalvar();
    },
    textoLacunaClicado(){
        // <div class="padThis"><div class="draggableLacuna lacunaAlternativa ui-draggable" style="position: relative;">mais</div></div>
        let selObj = window.getSelection(); 

        let selectedText = selObj.toString();
        console.log(selectedText);
        if(selectedText != " " && selectedText != ""){
            if(this.numeroDeLacunasAtual < 6){
                this.iframeLacunasContainer.innerHTML += "<div class='padThis'><div class='draggableLacuna lacunaAlternativa ui-draggable' style='position: relative;'>"+selectedText+"</div></div>";
                
                this.lacunasContainer.innerHTML += '<div id = "' + this.numeroDeLacunasAtual+'" class="palavraBox green" onclick="ScriptsCriarFaseLacuna.carregaParaEditar(this.id)"><h6>'+selectedText+'</h6></div>';
                    
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
    addDesafio(){
        if(this.desafio[this.idAtual].lacuna.length > 1){
            Console.log("Add desafio na fase");            
        }else{
            Console.log("Avisar que cada desafio precisa ter no minimo duas lacunas");
        }
    },
    checaLacuna: function(){
        let lacuna = this.newLacunaText.value;
        
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
        
        this.lacunaText = frase;

        //"<div class='padThis'><div id='lacuna1' class='emptyLacuna droppableLacuna ui-draggable'></div></div>"
        this.iframeFraseContainer.innerHTML = this.lacunaText;
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
    limpaElementos: function(){
        this.palavraTextEdit.value = "";
        this.radioResposta[0].checked = true;
        this.significadoTextEdit.value = "";
        this.dicaTextEdit.value = "";
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
                    
          // Post a user
          var url = "/CriarFase/SalvarFaseNormal";
        
          fase = {
              id: 123,
              usuarioId: 13,
              chave: "key13",
              idTipoFase: 0,
              descricao: "Uma fase",
              desafiosNormal: []
          };
          var listaDeDesafiosParaEnviar = [];
          for(var i = 0; i < this.listaDeDesafios.length;i++){
                listaDeDesafiosParaEnviar[i] = new this.desafio(null, this.listaDeDesafios[i].id, this.listaDeDesafios[i].palavra, this.listaDeDesafios[i].eCorreto, this.listaDeDesafios[i].faseId, this.listaDeDesafios[i].significado, this.listaDeDesafios[i].dica);
            }
          
            fase.desafiosNormal = listaDeDesafiosParaEnviar;
            var json = JSON.stringify(fase);
          //var json = this.listaDeDesafios;
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

          window.location.href = '/TaCertoForms/MinhasFases';
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

