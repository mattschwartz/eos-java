package com.eos.crud;

/**
 * Imports
 */
import java.util.HashMap;
import java.util.Map;

/**
 * QueryParameters
 */
public class QueryParameters
{
    /**
     * Data
     */
    private Map<String, Object> parameters = new HashMap<String, Object>();

    /**
     * Properties
     */
    public Map<String, Object> getParameters()
    {
        return parameters;
    }

    /**
     * Methods
     */
    public QueryParameters()
    {
    }

    /**
     * Constructs a new QueryParameters object.
     *
     * @param name The first parameter name.
     * @param value The first parameter value.
     */
    private QueryParameters(String name, Object value)
    {
        parameters = new HashMap<String, Object>();
        parameters.put(name, value);
    }

    /**
     * Constructs a new QueryParameters object with an intial parameter.
     *
     * @param name The first parameter name.
     * @param value The first parameter value.
     * @return The newly created QueryParameters object.
     */
    public static QueryParameters with(String name, Object value)
    {
        return new QueryParameters(name, value);
    }

    /**
     * Adds a parameter to the QueryParameters object.
     *
     * @param name The parameter name.
     * @param value The parameter value.
     * @return This QueryParameters object.
     */
    public QueryParameters and(String name, Object value)
    {
        parameters.put(name, value);
        return this;
    }

    public QueryParameters add(String name, Object value)
    {
        parameters.put(name, value);
        return this;
    }
}
