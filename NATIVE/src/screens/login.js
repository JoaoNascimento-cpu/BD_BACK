import React, { Component } from 'react';
import { ImageBackground, StyleSheet, Text, TextInput,TouchableOpacity, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';


import api from '../services/api';

export default class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : ''
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
        return (
            <section>
                <View style={styles.overlay} />
                <View style={styles.main}>
                    

                    <TextInput 
                        style={styles.inputLogin}
                        placeholder="username"
                        placeholderTextColor="#FFF"
                        keyboardType='email-address'
                        onChangeText={email => this.setState({ email })}
                    />

                    <TextInput 
                        style={styles.inputLogin}
                        placeholder="password"
                        placeholderTextColor="#FFF"
                        secureTextEntry={true}
                        onChangeText={senha => this.setState({ senha })}
                    />

                    <TouchableOpacity
                        style={styles.btnLogin}
                        onPress={this.realizarLogin}
                    >
                        <Text style={styles.btnLoginText}>login</Text>
                    </TouchableOpacity>
                    
                </View>
            </section>
        );
    }
};

const styles = StyleSheet.create({

    overlay: {
        ...StyleSheet.absoluteFillObject,
        backgroundColor: 'rgba(0, 0, 255, 0.79)'
    },

    // conteúdo da main
    main: {
        width: '100%',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center'
    },


    inputLogin: {
        width: 240,
        marginBottom: 40,
        fontSize: 18,
        color: '#FFF',
        borderBottomColor: '#FFF',
        borderBottomWidth: 2
    },

    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 38,
        width: 240,
        backgroundColor: '#FFF',
        borderColor: '#FFF',
        borderWidth: 1,
        borderRadius: 4,
        shadowOffset: { height: 1, width: 1 },
        marginTop: 20
    },

    btnLoginText: {
        fontSize: 12,
        fontFamily: 'Open Sans Light',
        color: '#B727FF',
        letterSpacing: 6,
        textTransform: 'uppercase'
    }
  
});