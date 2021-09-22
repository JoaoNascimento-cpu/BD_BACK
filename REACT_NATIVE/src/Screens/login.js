import React, { Component } from 'react';
import { Image, ImageBackground, StyleSheet, Text, TextInput, TouchableOpacity, View } from 'react-native';


// import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: ''
        }
    }

    realizarLogin = async () => {
        console.warn(this.state.email + ' ' + this.state.senha);

        try {

            const resposta = await api.post('/Login', {
                email: this.state.email,
                senha: this.state.senha,
            });

            const token = resposta.data.token;

            console.warn(token);

            await AsyncStorage.setItem('userToken', token);

            this.props.navigation.navigate('Main');

        } catch (error) {
            console.warn(error)
        }
    };

    render() {
        return (
            <ImageBackground
                //source={require('../../assets/img/login.png')}
                style={StyleSheet.absoluteFillObject}
            >
                <View style={styles.overlay} />
                <View style={styles.main}>

                    <Image
                        //source={require('../../assets/img/loginIcon2x.png')}
                        style={styles.mainImgLogin}
                    />

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
            </ImageBackground>
        );
    }
};
