import React, { Component } from 'react';

export class Message extends Component {
    static displayName = Message.name;
    constructor(props) {
        super(props);
        this.state = {
            phoneNumber : '',
            textMessage : '',
            senderName: '',
            messages: [],
            loading: true
        }
        this.handleSubmit = this.handleSubmit.bind(this);
        this.InputChange = this.InputChange.bind(this);
    }

    InputChange(event) {
        this.setState({ [event.target.name]: event.target.value })
    }

    handleSubmit(event) {
        this.sendMessage();
    }


    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Message.renderMessagesTable(this.state.messages);
        return (
            <div className="container">
                <h2>Сообщения</h2>
                <form name="messageForm" onSubmit={this.handleSubmit}>
                    <div className="col-3">
                        <input type="text" className="form-control" name="phoneNumber"
                            required placeholder="Телефонный номер" onChange={this.InputChange}  />
                    </div>
                    <div className="col-3">
                        <input type="text" className="form-control" name="textMessage"
                            required placeholder="Текс сообщения" onChange={this.InputChange} />
                    </div>
                    <div className="col-3">
                        <input type="text" className="form-control" name="senderName"
                             placeholder="Имя получателя" onChange={this.InputChange} />
                    </div>
                    <div className="col-3">
                        <button type="submit" id="submit" className="btn btn-primary"  >Отправить</button>
                    </div>

                </form>

                <h1 id="tabelLabel" >Таблица сообщений</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        )
    }

    async sendMessage() {
        const formData = new FormData();
        formData.append("phoneNumber", this.state.phoneNumber);
        formData.append("textMessage", this.state.textMessage);
        formData.append("senderName", this.state.senderName);
        debugger;
        const response = await fetch('api/message',
            {
                method: 'POST',
                body: formData
            });
        
        const data = await response.json();
    }
    componentDidMount() {
        this.populateMessagesData();
    }

    static renderMessagesTable(messages) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Дата</th>
                        <th>Текст Сообщения</th>
                        <th>Номер получателя</th>
                        <th>Статус</th>
                    </tr>
                </thead>
                <tbody>
                    {messages.map(message =>
                        <tr key={message.id}>
                            <td>{message.created}</td>
                            <td>{message.messageText}</td>
                            <td>{message.phoneNumber}</td>
                            <td>{message.status}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
 
    async populateMessagesData() {
        const response = await fetch('api/message')
        const data = await response.json();
        this.setState({ messages: data, loading: false });
    }
}






