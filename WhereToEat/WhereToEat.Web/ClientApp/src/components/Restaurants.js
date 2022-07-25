import React, { Component } from 'react';

export class Restaurants extends Component {
    static displayName = Restaurants.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        this.populateRestaurantsData();
    }

    static renderForecastsTable(forecasts) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>CreatedDate</th>
                        <th>RestaurantName</th>
                        <th>UserName</th>
                        <th>RestaurantAddresse</th>
                        <th>RestaurantDescription</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.RestaurantName}>
                            <td>{forecast.CreatedDate}</td>
                            <td>{forecast.RestaurantName}</td>
                            <td>{forecast.SuggestedBy.UserName}</td>
                            <td>{forecast.RestaurantAddresse}</td>
                            <td>{forecast.RestaurantDescription}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading ? <p><em>Loading...</em></p> : Restaurants.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" >In which restaurant to eat today?</h1>
                {contents}
            </div>
        );
    }

    async populateRestaurantsData() {
        const response = await fetch('restaurant');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
}
