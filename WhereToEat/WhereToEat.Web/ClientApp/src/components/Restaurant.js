import React, { Component } from 'react';

export class Restaurant extends Component {
    static displayName = Restaurant.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        this.populateRestaurantData();
    }

    static renderForecastsTable(forecast) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Name</th>
                        <th>Type</th>
                        <th>Place</th>
                        <th>Suggested by</th>
                    </tr>
                </thead>
                <tbody>
                    <tr key={forecast.restaurantName}>
                        <td>{forecast.createdDateString}</td>
                        <td>{forecast.restaurantName}</td>
                        <td>{forecast.restaurantDescription}</td>
                        <td>{forecast.restaurantAddresse}</td>
                        <td>{forecast.suggestedBy.userName}</td>
                    </tr>
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading ? <p><em>Loading...</em></p> : Restaurant.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" >Wich restaurant to eat at today ?</h1>
                {contents}
            </div>
        );
    }

    async populateRestaurantData() {
        const response = await fetch('restaurant');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });

        const response2 = fetch('restaurant/New', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: "test"
        }).then(r => r.json()).then(res => {
            if (res) {
                this.setState({ message: 'New Employee is Created Successfully' });
            }
        });
    }
}
