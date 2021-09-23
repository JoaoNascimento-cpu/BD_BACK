import React, { Component } from 'react'
import { StyleSheet, Image, Text, View, FlatList, TouchableOpacity, } from 'react-native'
import AsyncStorage from '@react-native-async-storage/async-storage'
impo
import api from '../Services/api'

export default class Main extends Component {
    constructor(props){
        super(props)
        this.state = {
            ListaProduto : []
        }
    }

ConsultaAssociada = async () => {
    const token = await AsyncStorage.getItem('wallfertas-chave-autenticacao')
    const dados = await api.get('/Produtos')

    const DadosAPi = dados.data

    this.setState({ListaProduto : DadosAPi})

    
}

Logout = async() => {
    try{
        await AsyncStorage.removeItem('userToken');
        this.props.navigation.navigate('Login');
    }catch(erro){
        console.warn(erro)
    }
};

componentDidMount() {
    this.ConsultaAssociada();
}

render(){
      return(
        <View style={styles.container}>
        <View style={styles.Header} >
        <Image source = {require('../../assets/img/pao.jpeg')} style = {styles.logo}/>
        </View>
        <Text style = {styles.tituloPag}>Ofertas</Text>
        <FlatList 
        data={this.state.ListaProduto}
        contentContainerStyle={styles.Lista}
        keyExtractor={item => item.idProduto}
        renderItem={this.renderItem}
        />
    </View>
      )
  }

  renderItem = ({item}) => (
    <View style={styles.container}>
        <View style={styles.linhaListar}>
            <Text style={styles.listaText}>Nome Produto: {item.nome}</Text>
        </View>
        <View style={styles.linhaListar}>           
            <Text style={styles.listaText}>Descrição: {item.descricao}</Text>
        </View>
        <View style={styles.linhaListar}>           
            <Text style={styles.listaText}>Preco: {item.preco}</Text>
        </View>
    </View>
)
}

const styles = StyleSheet.create({
  main: {
    flex: 1,
    backgroundColor: '#f1f1f1',
    
  },
  MainImg : {
    width : 100
  },
  container: {
    flex: 1,
    alignItems : 'left',
    backgroundColor: '#fff',
    marginTop : 45,
    marginBottom : 10,
    borderBottom : 3
  },

  contentConsulta: {
    width: 250,
    height: 140,
    fontSize: 19,
    paddingLeft: 14,
    marginRight: 20,
    marginBottom: 20,
    justifyContent: 'center'
  },

  logo : {
      width: 265,
      height : 165,
      marginLeft : 70,
      alignItems : 'center'
  },

  tituloPag : {
      fontSize : 18,
      textTransform : 'uppercase',
      letterSpacing : 6,
      color : 'black',
      marginTop : 50,
      fontWeight : 'bold',
      marginLeft : 60,
      alignItems : 'center'
  },

  listaText: {
    fontSize: 17,
    color: 'black',
    marginLeft : 50,
  },

  linhaListar: {
    flexDirection: 'row',
    alignItems: 'left',
    marginBottom: 10,
  },

  iconDesc : {
    width: 18,
    height: 18,
    tintColor: '#fff',
    marginRight : 15
  },

  iconName : {
      width: 16,
      height: 23,
      tintColor: '#fff',
      marginRight : 12,
      marginLeft : 4
  },

  iconTema : {
      width: 23,
      height : 18,
      tintColor: '#fff',
      marginRight : 10
  },
  Logout : {
      width : 20,
      height : 20,
      tintColor : 'black',
      marginTop : 95,          
  },
  Header : {
      flexDirection : 'row',
  }
});