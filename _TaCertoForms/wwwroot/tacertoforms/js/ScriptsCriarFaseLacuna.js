var ScriptsCriarFaseLacuna = {
    listaDeDesafios: [],
    quantidadeQuestoes: 0,
    idQuestaoAtual: 0,
    editando: -1,
    fraseCache: null,
    fraseSize: 0,
    wrongHelper: -2,
    lacunasAdicionadas:[{
        conteudo: "",
        index: 0
    }],
    desafio: function(index, id, faseId, significado, dica){
        if(index !== null)
            this.index = index;
        this.id = id;
        this.faseId = faseId;
        this.significado = significado;
        this.dica = dica;

        this.resposta = []
        this.fraseXLacuna = []

        this.addResposta = function(newResposta){
            this.resposta.push(newResposta)
        }

        this.addFraseXLacuna = function(newWord){
            this.fraseXLacuna.push(newWord)
        }
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
    numeroDeQuestoes: 0,
    questoesContainer: null,
    elemento: null, // Elemento que está sendo editado
    botaoAdd: null, // Elemento do botão de Adicionar palavra
    botaoEdit: null, // Elemento do botão de Editar palavra
    botaoSave: null, // Elemento do botão de Salvar fase
    botaoDeletar: null, // Elemento do botão de Deletar palavra

    loadData: function(){ // Carrega os dados que serão usados para mexer na página
        console.log("sdfsdfsdfs");
        this.lacunaText = document.getElementById('lacunaText');
        this.lacunaText.innerHTML = "";
        this.lacunaSecondText = document.getElementById('lacunaSecondText');
        this.newLacuna = document.getElementById('newLacunaText');
        this.significadoTextEdit = document.getElementById('textoSignificado');
        this.dicaTextEdit = document.getElementById('textoDica');
        this.lacunasContainer = document.getElementById('lacunasAdicionadas');
        this.numeroDeQuestoes = document.getElementById('numeroDeQuestoes')
        this.questoesContainer = document.getElementById('questoesAdicionadas')

        this.botaoAdd = document.getElementById('botaoAdd');
        this.botaoEdit = document.getElementById('botaoEdit');
        this.botaoSave = document.getElementById('botaoSave');
        this.botaoDeletar = document.getElementById('botaoApagar');
        
        this.iframe = document.getElementById('lacunaIframe');
        innerDoc = (this.iframe.contentDocument) ? this.iframe.contentDocument : this.iframe.contentWindow.document;
        this.iframeFraseContainer = innerDoc.getElementById('lacConteudoWrapper');        
        this.iframeLacunasContainer = innerDoc.getElementById('lacunaResp');
        this.wrongHelper = -2
        this.lacunaText.focus();  
        
    },
    addLacunaErrada: function(){ // Add lacuna errada na fase

        let lacuna = this.checaLacuna();
        
            //if(this.palavraNaoExiste(lacuna) || this.editando >= 0){

                if(this.editando == -1){ // Não está editando
                    
                    if(this.numeroDeLacunasAtual < 6){

                        if(this.checkIfCanAdd(lacuna, 1)){
                            this.wrongHelper = this.wrongHelper - 1
                            this.addNovaLacuna(1, lacuna, +this.wrongHelper);
                        }else{
                            this.mostraToast(8)
                        }
                        
                    }else{
                        this.mostraToast(6)
                    }
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
            
        //}else{
          //  console.log("Chama o toast para o usuario lembrar que tem que escrever uma palavra");
         ////   this.mostraToast(1); // Usuário não escreveu uma palavra
        //}

        this.newLacuna.focus();
        //this.mostraBotaoSalvar();
    },

    // Recebe a palavra clicada no texto do exemplo
    textoLacunaClicado(el){

        let clickedText = el.innerHTML.toString();
       
        if(el.classList.contains("transparentWord")){
            this.apagarLacunaPorId(+el.id)
            return
        }
        if(this.numeroDeLacunasAtual < 6){
            el.classList.add("transparentWord")
            
            if(this.checkIfCanAdd(+el.id, 0))
                this.addNovaLacuna(0, clickedText, +el.id);
            
        }else{
            this.mostraToast(6)
        }
    
    },

    checkIfCanAdd: function(idOrName, op){
        let canAdd = true
        if(op === 0){
            for(i = 0, q = this.numeroDeLacunasAtual;i<q && canAdd;i++){
                if(idOrName === this.lacunasAdicionadas[i].index)
                    canAdd = false
            }
        }else if(op === 1){
            for(i = 0, q = this.numeroDeLacunasAtual;i<q && canAdd;i++){
                if(idOrName === this.lacunasAdicionadas[i].conteudo)
                    canAdd = false
            }
        }
        
        return canAdd

    },

    addNovaLacuna(op, text, index){
        console.log(this.numeroDeLacunasAtual + "  " + text)
        this.lacunasAdicionadas.push({
            conteudo: text,
            index: index
        })
        this.numeroDeLacunasAtual = this.lacunasAdicionadas.length

        let div = document.createElement('div')
        div.innerHTML = text
        div.classList.add("draggableLacuna", "lacunaAlternativa", "ui-draggable")
        div.style.position = "relative"
        let divLac = document.createElement('div')
        divLac.appendChild(div)
        divLac.id = index
        divLac.classList.add("padThis")
        divLac.onclick = () => {
            this.apagarLacunaPorId(divLac.id)
        }

        if(op === 0){ // Add lacuna certa
            this.iframeLacunasContainer.appendChild(divLac)
                
            this.lacunasContainer.innerHTML += '<div id = "' + index+'" class="palavraBox green" onclick="ScriptsCriarFaseLacuna.apagarLacunaPorId(this.id)"><h6>'+text+'</h6></div>';
                    
        }else if(op == 1){ // Add lacuna errada

            this.iframeLacunasContainer.appendChild(divLac)

            this.lacunasContainer.innerHTML += '<div id ="'+index+'" class="palavraBox red" onclick="ScriptsCriarFaseLacuna.apagarLacunaPorId(this.id)"><h6>'+text+'</h6></div>';
        }

        this.mostraToast(2); // Lacuna adicionada

    },

    // Salva o desafio atual na fase atual
    addDesafio(){
        
        if(this.lacunaText.innerHTML.trim().length === 0){
            this.mostraToast(1)
            return
        }
        if(this.lacunasAdicionadas.length > 1){
            console.log("Add desafio na fase"); 

            let sig = this.significadoTextEdit.innerHTML
            if(sig === null) sig = ""
            let dica = this.dicaTextEdit.innerHTML
            if(dica === null) dica = ""

            this.listaDeDesafios[this.idAtual] = new this.desafio(this.idAtual, this.idAtual, "RXFS"+this.idAtual,sig, dica)
            
            // Add as lacunas no desafio.resposta
            for(i = 0; i < this.lacunasAdicionadas.length; i){
                if(this.lacunasAdicionadas[i].index < -1)
                    this.lacunasAdicionadas[i].index = -1

                this.listaDeDesafios[this.idAtual].addResposta({
                    conteudo: this.lacunasAdicionadas[i].conteudo,
                    posicao: this.lacunasAdicionadas[i].index
                })

                this.lacunasAdicionadas.splice(i, 1)
            }

            let words = this.iframeFraseContainer.childNodes.length
            // Add as palavras da frase no desafio.fraseXLacuna
            for(i = 0; i < words; i++){
                if(this.iframeFraseContainer.childNodes[i].classList.contains("transparentWord")){
                    this.listaDeDesafios[this.idAtual].addFraseXLacuna({
                        eFrase: false,
                    })
                }else{
                    this.listaDeDesafios[this.idAtual].addFraseXLacuna({
                        eFrase: true,
                        conteudo: this.iframeFraseContainer.childNodes[i].innerHTML
                    })
                }
            }
            
            this.numeroDeQuestoes.innerHTML = this.idAtual+1
            this.questoesContainer.innerHTML += '<div id = "' +this.idAtual+'" class="palavraBox purple" onclick="ScriptsCriarFaseLacuna.carregaParaEditar(this.id)"><h6>'+this.lacunaText.innerHTML+'</h6></div>';
            this.idAtual += 1
            this.numeroDeLacunasAtual = this.lacunasAdicionadas.length
            this.limpaElementos(1)
        }else{
            this.mostraToast(9)
        }
    },
    checaLacuna: function(){
        let lacuna = this.newLacuna.value;
        
        if(lacuna != false)
            return lacuna;
        lacuna = 0;
        return lacuna;
    },

    /*
     * Mostra toast de acordo com o op
     * op == 1 -> Usuário não digitou uma palavra 
     * op == 2 -> Lacuna foi adicionada
     * op == 3 -> Desafio de fase foi adicionado
     * op == 4 -> Desafio de fase editado
     * op == 5 -> Lacuna removida
     * op == 6 -> Número de lacunas é igual o máximo (6)
     * op == 7 -> Desafio de fase apagado
     * op == 8 -> Lacuna já existe
     * op == 9 -> Precisa no minimo duas lacunas
     */
    mostraToast: function(op){
        
        if(op == 1){ // Pessoa não digitou uma palavra
            //Materialize.toast('I am a toast!', 3000, 'blue rounded');
            M.toast({html: 'Você precisa digitar pelo menos uma palavra!', classes: 'rounded red lighten-1 palavraFaltandoModoNormal'});
        }else if(op == 2){ // Lacuna foi adicionada
            M.toast({html: 'Uma lacuna foi adicionada!', classes: 'rounded green lighten-1'});
        }else if(op == 3){
            M.toast({html: 'Questão adicianada!', classes: 'rounded green lighten-1'});
        }else if(op == 4){
            M.toast({html: 'Questão editada!', classes: 'rounded lime'});
        }else if(op == 5){
            M.toast({html: 'A lacuna foi removida!', classes: 'rounded red lighten-1'});
        }else if(op == 6){
            M.toast({html: 'O número máximo de lacunas é 6', classes: 'rounded lime'})
        }else if(op == 7){
            M.toast({html: 'Questão apagada!', classes: 'rounded red lighten-1'});
        }else if(op == 8){
            M.toast({html: 'A lacuna já existe!', classes: 'rounded lime'});
        }else if(op == 9){
            M.toast({html: 'A questão precisa ter no mínimo duas lacunas', classes: 'rounded lime'});
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
        this.fraseCache = frase
        
        let novaFrase = this.addSpans(frase)

        this.iframeFraseContainer.innerHTML = ""
        for(i = 0, l = novaFrase.length; i < l; i++){
            this.iframeFraseContainer.appendChild(novaFrase[i])
        }
    },

    addSpans: function(_frase){
        
        let frase = _frase

        let res = frase.split(' ')

        const resSize = res.length

        let remade = []
        for(i = 0; i < resSize; i++){
            let span = document.createElement('span')
            span.innerHTML = res[i]
            span.id = +i
            span.onclick = () => {
                this.textoLacunaClicado(span)
            }
            remade[i] = span
        }
        this.removeLacunasCertas(remade.length)
 
        return remade
    },

    // Remove as lacunas pois a frase foi refeita
    removeLacunasCertas: function(l){
        let lacunasContainer = this.lacunasContainer
        let lacunasContainerExample = this.iframeLacunasContainer
        if(this.fraseSize != 0){
            //if(this.fraseSize !== l){
                for(i = 0; i < this.lacunasAdicionadas.length; i++){
                    if(this.lacunasAdicionadas[i].index > -1){
                        this.lacunasAdicionadas.splice(i--, 1)
                        this.numeroDeLacunasAtual = this.lacunasAdicionadas.length
                    }
                }
                for(i = 0; i < lacunasContainer.childNodes.length; i++){
                    if(lacunasContainer.childNodes[i].id > -1){
                        console.log(lacunasContainer.childNodes[i].id)
                        lacunasContainer.removeChild(lacunasContainer.childNodes[i])
                        i--
                        this.mostraToast(5); // Lacuna apagada
                    }
                }
                for(i = 0; i < lacunasContainerExample.childNodes.length; i++){
                    if(lacunasContainerExample.childNodes[i].id > -1){
                        lacunasContainerExample.removeChild(lacunasContainerExample.childNodes[i])
                        i--
                    }
                }
            //}
        }
        this.fraseSize = l
        
        console.log(this.fraseSize)
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

    // Mostra o botão para salvar a fase caso ela possua pelo menos um desafio
    mostraBotaoSalvar: function(){

        if(this.quantidade == 0){
            this.botaoSave.classList.add("ghostElement");
        }else if(this.quantidade == 1){
            this.botaoSave.classList.remove("ghostElement");
        }
    },

    // Apaga a lacuna com o id recebido
    apagarLacunaPorId: function(index){
        index = +index
        let lacunasContainer = this.lacunasContainer
        let lacunasContainerExample = this.iframeLacunasContainer
        let fraseContainer = this.iframeFraseContainer
        let ok = false

        if(index !== -1){
            for(i = 0; i < fraseContainer.childNodes.length && !ok; i++){
                if(+fraseContainer.childNodes[i].id === index){
                    fraseContainer.childNodes[i].classList.remove("transparentWord")
                    ok = true
                }
            }
            ok = false
        }

        for(i = 0; i < this.lacunasAdicionadas.length && !ok; i++){
            console.log(this.lacunasAdicionadas[i].index + " "+ index)
            if(+this.lacunasAdicionadas[i].index === index){
                this.lacunasAdicionadas.splice(i--, 1)
                this.numeroDeLacunasAtual = this.lacunasAdicionadas.length
                ok = true
            }
        }
        ok = false

        for(i = 0; i < lacunasContainer.childNodes.length && !ok; i++){
            if(+lacunasContainer.childNodes[i].id === index){
                console.log(lacunasContainer.childNodes[i])
                lacunasContainer.removeChild(lacunasContainer.childNodes[i])
                i--
                ok = true
            }
        }
        ok = false

        for(i = 0; i < lacunasContainerExample.childNodes.length && !ok; i++){
            if(+lacunasContainerExample.childNodes[i].id === index){
                console.log(lacunasContainerExample.childNodes[i])
                lacunasContainerExample.removeChild(lacunasContainerExample.childNodes[i])
                i--
                ok = true
            }
        }
        this.mostraToast(5);    
    },

    // Apaga a lacuna clicada
    apagarLacuna: function(el){
        let quant = this.lacunasAdicionadas.length
        let palavra = ""
        let ok = false
        for(i = 0; i < quant && !ok;i++){
            console.log(el.firstChild.innerHTML + " === "+  this.lacunasAdicionadas[i].conteudo)
            if(el.firstChild.innerHTML === this.lacunasAdicionadas[i].conteudo){
                palavra = this.lacunasAdicionadas[i].conteudo
                this.lacunasAdicionadas.splice(i, 1)
                ok = true
            }
        }
        el.parentNode.removeChild(el)

        if(palavra != "")
            this.apagaLacunaDoExemplo(palavra, quant)

        this.numeroDeLacunasAtual = this.lacunasAdicionadas.length

        this.mostraToast(5); // Lacuna apagada

    },

    // Apaga a lacuna do exemplo também
    apagaLacunaDoExemplo: function(palavra, quant){

        let lacunasContainer = this.iframeLacunasContainer
        console.log("quantidade = " + quant)
        let ok = false

        for(i = 0; i < quant && !ok; i++){
            if(lacunasContainer.children[i].firstChild.innerHTML === palavra){
                console.log(lacunasContainer.children[i].firstChild.innerHTML + " === " + palavra)
                lacunasContainer.removeChild(lacunasContainer.children[i])
                ok = true
            }
        }
    },

    // Apaga o desafio que está sendo editado no momento
    apagarDesafio: function(){
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
            this.lacunaText.innerHTML = "";
            this.lacunasContainer.innerHTML = null;
            this.iframeFraseContainer.innerHTML = null
            this.iframeLacunasContainer.innerHTML = null
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
    focusOnMe: function(el, flag){
        console.log(el.innerHTML + "  " +flag)
        if(flag){
            el.classList.add("cloneActive");
        }else if(el.innerHTML == ""){
            el.classList.remove("cloneActive");
        }
    },
}

window.onload = ()=>{
    ScriptsCriarFaseLacuna.loadData();
};