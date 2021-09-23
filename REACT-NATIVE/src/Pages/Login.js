import React, { Component } from 'react';
import { Image, ImageBackground, StyleSheet, Text, TextInput,TouchableOpacity, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import api from '../Services/api.js';

export default class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
        }
    }

    realizarLogin = async () => {
      console.warn(this.state.email + ' ' + this.state.senha);

      try {
          
          const resposta = await api.post('/Login', {
              email : this.state.email,
              senha : this.state.senha,
          });
  
          const token = resposta.data.token;
          
          console.warn(token);
          
          await AsyncStorage.setItem('userToken', token);
          
          this.props.navigation.navigate('Main');

      } catch (error) {
          console.warn(error)
      }
  };

render(){
        return(
            <View style={styles.imageBackground}>
            <Image source={require('../../assets/img/w2.png')} style={styles.imagelogo}/>
              <View style={styles.containerLogin}>
                <TextInput
                  placeholder = 'E-Mail'
                  placeholderTextColor = '#fff'
                  keyboardType = 'email-address'
                  style={styles.inputCadastro}
                  onChangeText={email => this.setState({ email })}
                  value = {this.state.email}
                />
    
                <TextInput
                  placeholder = 'Senha'
                  placeholderTextColor = '#fff'
                  secureTextEntry = {true}
                  style={styles.inputCadastro}
                  onChangeText={senha => this.setState({ senha })}
                  value = {this.state.senha}
                />
    
                  <TouchableOpacity
                      style={styles.btnLogin}
                      onPress={this.realizarLogin()}
                  >
                      <Text style={styles.btnLoginText}>login</Text>
                    </TouchableOpacity>
              </View>
            </View>
        )
    }
}
const styles = StyleSheet.create({
  imageBackground : {
    flex: 1,
    justifyContent: 'center',
    backgroundColor : 'blue'
  },

  imagelogo : {
    marginTop : 10,
    marginLeft : '25%',
    marginBottom : -150,
    width : '50%',
    flex : 0.4
    
  },
  inputCadastro : {
    width: 260,
    height: 40, 
    backgroundColor: '#7C8FA6',
    marginBottom: 25,
    paddingLeft: 15,
    borderRadius : 4,
    shadowColor :'#000',
    shadowOffset : {
        width: 2, height: 2
    },
    shadowOpacity: 0.2
  },

  btnLogin : {
    backgroundColor: '#275C9F',
    width: 120,
    height: 30,
    borderRadius: 4,
    textAlign: 'center',
    paddingTop: 5,
    shadowColor :'#000',
    shadowOffset : {
        width: 3, height: 3
    },
    shadowOpacity: 0.3,
  },

  btnText : {
    color: '#fff'
  },

  containerLogin : {
    marginTop: '30%',
    alignItems: 'center',
  }
})


