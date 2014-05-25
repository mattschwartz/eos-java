package com.eos.crud;

/**
 * Imports
 */
import java.beans.BeanInfo;
import java.beans.IntrospectionException;
import java.beans.Introspector;
import java.beans.PropertyDescriptor;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.List;

/**
 * AnnotationUtility
 */
public class AnnotationUtility 
{

    /**
     * Private constructor to prevent instantiation.
     */
    private AnnotationUtility() {}
    
    /**
     * Finds all methods annotated with annotationType and the accessor methods
     * for fields annotated with annotationType in targetClass
     * @param targetClass the class to inspect
     * @param annotationType the annotation to look for
     * @return a list of all methods that are annotated with annotationType
     */
    public static List<Method> getAllAnnotatedProperties( Class targetClass, Class annotationType ) 
    {
        if( targetClass == null ) {
            throw new IllegalArgumentException( "targetClass can not be null" );
        }
        if( annotationType == null ) {
            throw new IllegalArgumentException( "annotationType can not be null" );
        }
        if( !annotationType.isAnnotation() ) {
            throw new IllegalArgumentException( "annotationType must be an Annotation but was " + annotationType.getSimpleName() );
        }
        List<Method> response = new ArrayList<Method>();
        /* Looks for Methods annotated with javax.persistence.Id */
        for( Method tmpMethod : targetClass.getMethods() ) {
            if ( tmpMethod.isAnnotationPresent( annotationType ) ) {
                response.add( tmpMethod );
            }
        }
        /* If no method found look for fields annotated with javax.persistence.Id */
        try {
            Field[] declaredFields = targetClass.getDeclaredFields();
            for( Field field : declaredFields ) {
                if( field.isAnnotationPresent( annotationType ) ) {
                    BeanInfo beanInfo = Introspector.getBeanInfo( targetClass );
                    PropertyDescriptor[] propertyDescriptors = beanInfo.getPropertyDescriptors();
                    for( PropertyDescriptor descriptor : propertyDescriptors ) {
                        if( descriptor.getName().equals( field.getName() ) ) {
                            response.add( descriptor.getReadMethod() );
                        }
                    }
                }
            }
        } catch ( IntrospectionException ex ) {
            throw new IllegalArgumentException( "Unable to introspect class: " + targetClass.getSimpleName(), ex );
        }
        return response;
    }

    /**
     * Finds a method annotated with annotationType or the accessor method
     * for a field annotated with javax.persistence.Id
     * @param targetClass the class to inspect
     * @param annotationType the annotation to look for
     * @return a single method annotated with this Annotation
     */
    public static Method getFirstAnnotatedProperty( Class targetClass, Class annotationType ) 
    {
        List<Method> methodList = getAllAnnotatedProperties( targetClass, annotationType );
        if( methodList.size() == 0 )  {
            throw new IllegalArgumentException( targetClass.getSimpleName() + " does not have any fields/methods annotated with " + annotationType.getSimpleName() );
        }
        return methodList.get(0);
    }}
